using System;
using TaskFrom1C.Character;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;

namespace TaskFrom1C.Application.Commands
{
    public class SetupUICommand : ICommand
    {
        public event Action OnDone;
        
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly ICharacterController _characterController;

        private const string UIHealthBarSource = "UIHealthBar";
        private const string UIBaseLineSource = "UIBaseLine";
        private const string UIEndGameWindowSource = "UIEndGameWindow";

        public SetupUICommand(
        ISceneObjectStorage sceneObjectStorage,
        ICharacterController characterController)
        {
            _sceneObjectStorage = sceneObjectStorage;
            _characterController = characterController;
        }
        
        public void Execute()
        {
            var canvas = _sceneObjectStorage.Get<GameCanvas>();

            var healthBar = _sceneObjectStorage.CreateFromResourcesAndAdd<UIHealthBar>(
                UIHealthBarSource,
                canvas.Container);

            healthBar.SetHealthValue(_characterController.CurrentHealth);

            ResetLocalPositionAndLocalScale(healthBar.transform);
            
            var baseLine = _sceneObjectStorage.CreateFromResourcesAndAdd<UIBaseLine>(
                UIBaseLineSource,
                canvas.Container);

            ResetLocalPositionAndLocalScale(baseLine.transform);
            
            var endGameWindow = _sceneObjectStorage.CreateFromResourcesAndAdd<UIEndGameWindow>(
                UIEndGameWindowSource,
                canvas.Container);

            ResetLocalPositionAndLocalScale(endGameWindow.transform);

            _characterController.OnDeath += () =>
            {
                endGameWindow.SetText(true);
                endGameWindow.gameObject.SetActive(true);
            };

            OnDone?.Invoke();
        }

        private void ResetLocalPositionAndLocalScale(Transform transform)
        {
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
        }
    }
}