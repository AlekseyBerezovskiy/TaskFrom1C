using TaskFrom1C.Character.Bullet;
using TaskFrom1C.Character.Input;
using Zenject;

namespace TaskFrom1C.Character
{
    public class CharacterInstaller : Installer<CharacterInstaller>
    {
        private const string CharacterConfigSource = "CharacterConfig";
        private const string CharacterViewSource = "CharacterView";
        private const string BulletViewSource = "BulletView";
        
        private const string BulletContainerName = "BulletContainer";
        
        public override void InstallBindings()
        {
            Container
                .Bind<InputController>()
                .AsSingle();
            
            Container
                .Bind<CharacterConfig>()
                .FromScriptableObjectResource(CharacterConfigSource)
                .AsSingle();

            Container
                .Bind<CharacterView>()
                .FromComponentInNewPrefabResource(CharacterViewSource)
                .AsSingle();
            
            Container
                .BindFactory<BulletView, BulletView.Factory>()
                .FromComponentInNewPrefabResource(BulletViewSource)
                .UnderTransformGroup(BulletContainerName);
            
            Container
                .Bind<ICharacterController>()
                .To<CharacterController>()
                .AsSingle();
        }
    }
}