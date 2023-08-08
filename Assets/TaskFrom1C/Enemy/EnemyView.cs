using System;
using UnityEngine;

namespace TaskFrom1C.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public event Action OnTakeBullet;
        public event Action OnTouchBaseLine;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Base"))
            {
                OnTouchBaseLine?.Invoke();
            }
            else if (other.CompareTag("Bullet"))
            {
                OnTakeBullet?.Invoke();
            }
        }
    }
}