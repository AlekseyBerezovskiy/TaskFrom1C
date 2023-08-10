using DG.Tweening;
using UnityEngine;
using Zenject;
using CharacterController = TaskFrom1C.Character.CharacterController;

namespace TaskFrom1C.Enemy
{
    public class EnemyController
    {
        public EnemyView View { get; }
        
        private float _currentHealth;
        private Tween _moveTween;
        
        private readonly EnemyData _enemyData;
        private readonly Transform _target;
        private readonly CharacterController _characterController;

        public EnemyController(
            EnemyView view,
            EnemyData enemyData,
            Transform target,
            CharacterController characterController)
        {
            View = Object.Instantiate(view);
            
            _enemyData = enemyData;
            _target = target;
            _characterController = characterController;

            _currentHealth = _enemyData.Health;
            
            _characterController.OnDeath += Death;
            
            View.OnTakeBullet += TakeBullet;
            View.OnTouchBaseLine += TouchBaseLine;
            
            Move();
        }

        private void Move()
        {
            var distance = Vector3.Distance(View.transform.position, _target.position);
            
            _moveTween = View.transform.DOMoveY(_target.position.y,distance / _enemyData.Speed);
        }
        
        private void TakeBullet()
        {
            
        }

        private void TouchBaseLine()
        {
            Death();
            _characterController.TakeDamage(_enemyData.Damage);
        }

        private void Death()
        {
            _characterController.OnDeath -= Death;
            
            View.OnTakeBullet -= TakeBullet;
            View.OnTouchBaseLine -= TouchBaseLine;
            
            _moveTween?.Kill();
            _moveTween = null;
            
            Object.Destroy(View.gameObject);
        }
        
        public class Factory : PlaceholderFactory<EnemyData, Transform, EnemyController>
        { }
    }
}