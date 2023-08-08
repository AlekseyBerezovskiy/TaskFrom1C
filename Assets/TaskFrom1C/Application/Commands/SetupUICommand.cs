using System;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;

namespace TaskFrom1C.Application.Commands
{
    public class SetupUICommand : ICommand
    {
        public event Action OnDone;
        
        private readonly ISceneObjectStorage _sceneObjectStorage;

        private const string UIHealthBarSource = "UIHealthBar";
        private const string UIBaseLineSource = "UIBaseLine";

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

            ResetLocalPositionAndLocalScale(healthBar.transform);
            
            var baseLine = _sceneObjectStorage.CreateFromResourcesAndAdd<UIBaseLine>(
                UIBaseLineSource,
                canvas.Container);

            ResetLocalPositionAndLocalScale(baseLine.transform);
            
            OnDone?.Invoke();
        }

        private void ResetLocalPositionAndLocalScale(Transform transform)
        {
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
        }
    }
}