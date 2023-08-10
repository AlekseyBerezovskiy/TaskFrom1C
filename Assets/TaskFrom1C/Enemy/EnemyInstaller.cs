using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        private const string EnemyViewSource = "EnemyView";
        private const string WaveConfigSource = "WaveConfig";
        
        public override void InstallBindings()
        {
            Container
                .Bind<EnemyView>()
                .FromResources(EnemyViewSource)
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
                .FromScriptableObjectResource(WaveConfigSource)
                .AsSingle();

            Container
                .Bind<IWaveController>()
                .To<WaveController>()
                .AsSingle();
        }
    }
}