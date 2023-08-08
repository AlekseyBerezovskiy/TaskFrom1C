using TaskFrom1C.Character.Input;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Character
{
    public class CharacterController 
    {
        private readonly CharacterView _characterView;
        private readonly CharacterConfig _characterConfig;
        private readonly UIHealthBar _uiHealthBar;

        private float _currentHealth;
        
        public CharacterController(
            CharacterView characterView,
            CharacterConfig characterConfig,
            InputController inputController,
            ISceneObjectStorage sceneObjectStorage)
        {
            _characterView = characterView;
            _characterConfig = characterConfig;
            _uiHealthBar = sceneObjectStorage.Get<UIHealthBar>();

            inputController.OnMoveButtonClick += Move;
        }
        
        public void TakeDamage(CharacterDamageSignal damageSignal)
        {
            _currentHealth -= damageSignal.Damage;
            _uiHealthBar.SetHealthValue(_currentHealth);

            if (_currentHealth <= 0)
            {
                Object.Destroy(_characterView);
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

    public class CharacterDamageSignal
    {
        public float Damage;
    }
}
