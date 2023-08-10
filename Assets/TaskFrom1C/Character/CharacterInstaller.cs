using TaskFrom1C.Character.Bullet;
using TaskFrom1C.Character.Input;
using Zenject;

namespace TaskFrom1C.Character
{
    public class CharacterInstaller : Installer<CharacterInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<InputController>()
                .AsSingle();
            
            Container
                .Bind<CharacterConfig>()
                .FromScriptableObjectResource("CharacterConfig")
                .AsSingle();

            Container
                .Bind<CharacterView>()
                .FromComponentInNewPrefabResource("CharacterView")
                .AsSingle();
            
            Container
                .BindFactory<BulletView, BulletView.Factory>()
                .FromComponentInNewPrefabResource("BulletView")
                .UnderTransformGroup("BulletContainer");
            
            Container
                .Bind<ICharacterController>()
                .To<CharacterController>()
                .AsSingle();
        }
    }
}