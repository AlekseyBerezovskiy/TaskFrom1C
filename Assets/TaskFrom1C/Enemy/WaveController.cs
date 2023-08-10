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
        private readonly EnemyController.Factory _enemyFactory;
        private readonly CharacterController _characterController;

        private SpawnpointData[] _spawnpointDatas;
        private Tween _delayTween;

        public WaveController(
            WaveConfig waveConfig,
            ISceneObjectStorage sceneObjectStorage,
            EnemyController.Factory enemyFactory,
            CharacterController characterController)
        {
            _waveConfig = waveConfig;
            _sceneObjectStorage = sceneObjectStorage;
            _enemyFactory = enemyFactory;
            _characterController = characterController;

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
                
                var enemyViewTransform = _enemyFactory.Create(
                    _waveConfig.EnemyData, 
                    _spawnpointDatas[pointIndex].Target).View.transform;
                
                enemyViewTransform.SetParent(_spawnpointDatas[pointIndex].Spawnpoint);
                enemyViewTransform.localPosition = Vector3.zero;    
                
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