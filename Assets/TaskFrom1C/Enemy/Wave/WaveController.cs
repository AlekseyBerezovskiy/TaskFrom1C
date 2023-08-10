using DG.Tweening;
using TaskFrom1C.Character;
using TaskFrom1C.Level;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;

namespace TaskFrom1C.Enemy
{
    public class WaveController : IWaveController
    {
        private readonly WaveConfig _waveConfig;
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICharacterController _characterController;
        private readonly IEnemyStorage _enemyStorage;

        private SpawnpointData[] _spawnpointDatas;
        private Tween _delayTween;
        private int _enemyCountToWin;
        private int _currentDeathEnemy;
        
        public WaveController(
            WaveConfig waveConfig,
            ISceneObjectStorage sceneObjectStorage,
            IEnemyFactory enemyFactory,
            ICharacterController characterController,
            IEnemyStorage enemyStorage)
        {
            _waveConfig = waveConfig;
            _sceneObjectStorage = sceneObjectStorage;
            _enemyFactory = enemyFactory;
            _characterController = characterController;
            _enemyStorage = enemyStorage;

            _characterController.OnDeath += StopSpawn;
        }

        public void StartWave()
        {
            var levelView = _sceneObjectStorage.Get<LevelView>();
            _spawnpointDatas = levelView.SpawnpointDatas;

            _enemyCountToWin = Random.Range(_waveConfig.MinEnemyToWin, _waveConfig.MaxEnemyToWin);
            
            SpawnEnemy();
        }
        
        private void SpawnEnemy()
        {
            _delayTween = DOVirtual.DelayedCall(
            Random.Range(_waveConfig.MinSpawnsRate, _waveConfig.MaxSpawnsRate),
             () =>
            {
                var pointIndex = Random.Range(0, _spawnpointDatas.Length);

                var enemyController = 
                    _enemyFactory
                        .Create(_spawnpointDatas[pointIndex].Target);

                enemyController.OnDeathWithBullets += IncrementDeathWithBulletsEnemy;
                
                var enemyViewTransform = enemyController.View.transform;
                
                enemyViewTransform.SetParent(_spawnpointDatas[pointIndex].Spawnpoint);
                enemyViewTransform.localPosition = Vector3.zero;    
                
                _enemyStorage.AddEnemy(enemyController);
                
                SpawnEnemy();
            });
        }

        private void StopSpawn()
        {
            _characterController.OnDeath -= StopSpawn;
            
            _delayTween?.Kill();
            _delayTween = null;
        }

        private void IncrementDeathWithBulletsEnemy()
        {
            _currentDeathEnemy++;
            
            if (_enemyCountToWin <= _currentDeathEnemy)
            {
                _characterController.Death();

                var enemies = _enemyStorage.GetAllEnemy();

                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Death();
                }
                
                StopSpawn();
                
                var uiEndGameWindow = _sceneObjectStorage.Get<UIEndGameWindow>();
                uiEndGameWindow.SetText(false);
                uiEndGameWindow.gameObject.SetActive(true);
            }
        }
    }
}