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
                .AsSingle();
        }
    }
}