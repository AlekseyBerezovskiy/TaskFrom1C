using DG.Tweening;
using TaskFrom1C.Level;
using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;
using CharacterController = TaskFrom1C.Character.CharacterController;

namespace TaskFrom1C.Enemy
{
    public class WaveController : IWaveController
    {
        private readonly WaveConfig _waveConfig;
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly IEnemyFactory _enemyFactory;
        private readonly CharacterController _characterController;
        private readonly IEnemyStorage _enemyStorage;

        private SpawnpointData[] _spawnpointDatas;
        private Tween _delayTween;

        public WaveController(
            WaveConfig waveConfig,
            ISceneObjectStorage sceneObjectStorage,
            IEnemyFactory enemyFactory,
            CharacterController characterController,
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
            
            SpawnEnemy();
        }
        
        private void SpawnEnemy()
        {
            _delayTween = DOVirtual.DelayedCall(_waveConfig.SpawnsRate, () =>
            {
                var pointIndex = Random.Range(0, _spawnpointDatas.Length);

                var enemyController = 
                    _enemyFactory
                        .Create(_spawnpointDatas[pointIndex].Target);

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
    }
}