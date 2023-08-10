using System;
using TaskFrom1C.Character.Input;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TaskFrom1C.Character
{
    public class CharacterController
    {
        public Action OnDeath;
        public float CurrentHealth { get; private set; }
        
        private UIHealthBar _uiHealthBar;
        
        private readonly CharacterView _characterView;
        private readonly CharacterConfig _characterConfig;
        private readonly ISceneObjectStorage _sceneObjectStorage;

        public CharacterController(
            CharacterView characterView,
            CharacterConfig characterConfig,
            InputController inputController,
            ISceneObjectStorage sceneObjectStorage)
        {
            _characterView = characterView;
            _characterConfig = characterConfig;
            _sceneObjectStorage = sceneObjectStorage;

            CurrentHealth = _characterConfig.Health;

            inputController.OnMoveButtonClick += Move;
        }
        
        public void TakeDamage(float damage)
        {
            if (_uiHealthBar == null)
            {
                _uiHealthBar = _sceneObjectStorage.Get<UIHealthBar>();
            }
            
            CurrentHealth -= damage;
            _uiHealthBar.SetHealthValue(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
                Object.Destroy(_characterView.gameObject);
            }
        }

        private void Move(Vector2 direction)
        {
            var charTransform = _characterView.transform;
            
            charTransform.position =
                Vector3.MoveTowards(
                    charTransform.position, 
                    charTransform.position + (Vector3)direction, 
                    Time.deltaTime * _characterConfig.Speed);
        }
    }
}
