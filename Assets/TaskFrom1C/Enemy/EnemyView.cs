using System;
using TaskFrom1C.Character;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public event Action<float> OnTakeBullet;
        public event Action OnTouchBaseLine;

        private CharacterConfig _characterConfig;
        
      //  [Inject]
        private void Inject(CharacterConfig characterConfig)
        {
            _characterConfig = characterConfig;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Base"))
            {
                OnTouchBaseLine?.Invoke();
            }
            else if (other.CompareTag("Bullet"))
            {
                OnTakeBullet?.Invoke(_characterConfig.Damage);
            }
        }
    }
}