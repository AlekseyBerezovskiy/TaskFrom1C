using TaskFrom1C.Character.Input;
using UnityEngine;

namespace TaskFrom1C.Character
{
    public class CharacterController 
    {
        private readonly CharacterView _characterView;
        private readonly CharacterConfig _characterConfig;

        public CharacterController(
            CharacterView characterView,
            CharacterConfig characterConfig,
            InputController inputController)
        {
            _characterView = characterView;
            _characterConfig = characterConfig;

            inputController.OnMoveButtonClick += Move;
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
