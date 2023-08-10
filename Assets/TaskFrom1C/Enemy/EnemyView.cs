using System;
using TaskFrom1C.Character;
using TaskFrom1C.Character.Bullet;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public event Action<int> OnTakeBullet;
        public event Action OnTouchBaseLine;

        private CharacterConfig _characterConfig;
        
        [Inject]
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
                var bulletView = other.GetComponent<BulletView>();
                bulletView.Destroy();
                
                OnTakeBullet?.Invoke(_characterConfig.BulletData.Damage);
            }
        }
    }
}