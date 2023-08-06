using TaskFrom1C.Character;
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

            CharacterInstaller.Install(Container);
            
            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}
