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

            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();

            Container
                .Bind<IEnemyStorage>()
                .To<EnemyStorage>()
                .AsSingle();
            
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