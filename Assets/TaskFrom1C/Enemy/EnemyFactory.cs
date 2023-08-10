using UnityEngine;
using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly WaveConfig _waveConfig;
        private readonly IInstantiator _instantiator;
        private readonly EnemyView _enemyView;

        public EnemyFactory(
            WaveConfig waveConfig,
            IInstantiator instantiator,
            EnemyView enemyView)
        {
            _waveConfig = waveConfig;
            _instantiator = instantiator;
            _enemyView = enemyView;
        }
        
        public EnemyController Create(Transform parent)
        {
            var enemyView = _instantiator.InstantiatePrefabForComponent<EnemyView>(_enemyView);
            
            var enemyController = _instantiator
                .Instantiate<EnemyController>(
                    new object[]{parent, _waveConfig.EnemyData, enemyView});

            return enemyController;
        }
    }
}