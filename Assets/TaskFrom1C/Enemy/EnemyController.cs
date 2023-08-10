using System;
using DG.Tweening;
using TaskFrom1C.Character;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TaskFrom1C.Enemy
{
    public class EnemyController
    {
        public event Action OnDeathWithBullets;
        public EnemyView View => _view;
        
        private int _currentHealth;
        
        private Tween _moveTween;
        
        private readonly EnemyView _view;
        private readonly EnemyData _enemyData;
        private readonly Transform _target;
        private readonly ICharacterController _characterController;
        private readonly IEnemyStorage _enemyStorage;

        public EnemyController(
            EnemyView enemyView,
            EnemyData enemyData,
            Transform target,
            ICharacterController characterController,
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
        
        public void Death()
        {
            _characterController.OnDeath -= Death;
            
            _view.OnTakeBullet -= TakeDamage;
            _view.OnTouchBaseLine -= TouchBaseLine;

            _moveTween?.Kill();
            _moveTween = null;
            
            Object.Destroy(_view.gameObject);
        }

        private void Move()
        {
            var distance = Vector3.Distance(_view.transform.position, _target.position);
            
            _moveTween = _view.transform.DOMoveY(
                _target.position.y,
                distance / Random.Range(_enemyData.MinSpeed, _enemyData.MaxSpeed));
        }
        
        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                OnDeathWithBullets?.Invoke();
                _enemyStorage.DeleteEnemy(_view.gameObject.GetInstanceID());
                Death();
            }
        }

        private void TouchBaseLine()
        {
            Death();
            _characterController.TakeDamage(_enemyData.Damage);
        }
    }
}