using System;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using TaskFrom1C.UI.UIHealthBar;
using UnityEngine;

namespace TaskFrom1C.Application.Commands
{
    public class SetupUICommand : ICommand
    {
        public event Action OnDone;
        
        private readonly ISceneObjectStorage _sceneObjectStorage;

        private const string UIHealthBarSource = "UIHealthBar";

        public SetupUICommand(ISceneObjectStorage sceneObjectStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
        }
        
        public void Execute()
        {
            var canvas = _sceneObjectStorage.Get<GameCanvas>();

            var healthBar = _sceneObjectStorage.CreateFromResourcesAndAdd<UIHealthBar>(
                UIHealthBarSource,
                canvas.Container);

            var heathBarTransform = healthBar.transform;
            heathBarTransform.localScale = Vector3.one;
            heathBarTransform.localPosition = Vector3.zero;
            
            OnDone?.Invoke();
        }
    }
}