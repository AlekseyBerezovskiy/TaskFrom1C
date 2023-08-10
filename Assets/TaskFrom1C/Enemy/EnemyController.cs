using System;
using DG.Tweening;
using UnityEngine;
using CharacterController = TaskFrom1C.Character.CharacterController;
using Object = UnityEngine.Object;

namespace TaskFrom1C.Enemy
{
    public class EnemyController
    {
        public event Action OnDeath;
        public EnemyView View => _view;
        
        private float _currentHealth;
        
        private Tween _moveTween;
        
        private readonly EnemyView _view;
        private readonly EnemyData _enemyData;
        private readonly Transform _target;
        private readonly CharacterController _characterController;
        private readonly IEnemyStorage _enemyStorage;

        public EnemyController(
            EnemyView enemyView,
            EnemyData enemyData,
            Transform target,
            CharacterController characterController,
            IEnemyStorage enemyStorage)
        {
            _enemyData = enemyData;
            _target = target;
            _characterController = characterController;
            _enemyStorage = enemyStorage;

            _currentHealth = _enemyData.Health;
            
            _characterController.OnDeath += Death;

            _view = enemyView;
            
            _view.OnTakeBullet += TakeDamage;
            _view.OnTouchBaseLine += TouchBaseLine;
            
            Move();
        }

        private void Move()
        {
            var distance = Vector3.Distance(_view.transform.position, _target.position);
            
            _moveTween = _view.transform.DOMoveY(_target.position.y,distance / _enemyData.Speed);
        }
        
        private void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
                Object.Destroy(View.gameObject);
            }
        }

        private void TouchBaseLine()
        {
            Death();
            _characterController.TakeDamage(_enemyData.Damage);
        }

        private void Death()
        {
            _characterController.OnDeath -= Death;
            
            _view.OnTakeBullet -= TakeDamage;
            _view.OnTouchBaseLine -= TouchBaseLine;

            _enemyStorage.DeleteEnemy(_view.gameObject.GetInstanceID());
            
            _moveTween?.Kill();
            _moveTween = null;
            
            Object.Destroy(_view.gameObject);
        }
    }
}