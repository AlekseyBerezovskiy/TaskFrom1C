using TaskFrom1C.Character;
using TaskFrom1C.Enemy;
using TaskFrom1C.SceneObjectsStorage;
using Zenject;

namespace TaskFrom1C.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISceneObjectStorage>()
                .To<SceneObjectStorage>()
                .AsSingle();

            SignalBusInstaller.Install(Container);
            
            EnemyInstaller.Install(Container);
            
            CharacterInstaller.Install(Container);

            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}
