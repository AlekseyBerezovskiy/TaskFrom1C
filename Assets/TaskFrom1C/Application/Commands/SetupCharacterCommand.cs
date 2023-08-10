using System;
using TaskFrom1C.Character;
using TaskFrom1C.SceneObjectsStorage;
using Zenject;

namespace TaskFrom1C.Application.Commands
{
    public class SetupCharacterCommand : ICommand
    {
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly IInstantiator _instantiator;
        private readonly CharacterView _characterView;
        public event Action OnDone;

        public SetupCharacterCommand(
            ISceneObjectStorage sceneObjectStorage,
            IInstantiator instantiator,
            CharacterView characterView)
        {
            _sceneObjectStorage = sceneObjectStorage;
            _instantiator = instantiator;
            _characterView = characterView;
        }
        
        public void Execute()
        {
            _instantiator.Instantiate<CharacterController>(new []{_characterView});
            
            _sceneObjectStorage.Add<CharacterView>(_characterView);

            OnDone?.Invoke();
        }
    }
}