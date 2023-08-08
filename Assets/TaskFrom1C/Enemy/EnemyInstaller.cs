using UnityEngine;
using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EnemyView>()
                .FromResources("EnemyView")
                .AsSingle();
            
            Container.BindFactory<EnemyData, Transform, EnemyController, EnemyController.Factory>();

            Container
                .Bind<WaveConfig>()
                .FromScriptableObjectResource("WaveConfig")
                .AsSingle();

            Container
                .Bind<IWaveController>()
                .To<WaveController>()
                .AsSingle();
        }
    }
}