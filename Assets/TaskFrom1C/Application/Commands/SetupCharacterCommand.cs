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
        public event Action OnDone;

        public SetupCharacterCommand(
            ISceneObjectStorage sceneObjectStorage,
            IInstantiator instantiator)
        {
            _sceneObjectStorage = sceneObjectStorage;
            _instantiator = instantiator;
        }
        
        public void Execute()
        {
            var characterView = _sceneObjectStorage.CreateFromResourcesAndAdd<CharacterView>("CharacterView");
            
            _instantiator.Instantiate<CharacterController>(new []{characterView});
            
            OnDone?.Invoke();
        }
    }
}