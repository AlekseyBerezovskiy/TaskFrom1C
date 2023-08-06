using System;
using TaskFrom1C.SceneObjectsStorage;

namespace TaskFrom1C.Application.Commands
{
    public class SetupCharacter : ICommand
    {
        public event Action OnDone;

        private readonly ISceneObjectStorage _sceneObjectStorage;
        
        public SetupCharacter(ISceneObjectStorage sceneObjectStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
        }
        
        public void Execute()
        {
            
        }
    }
}