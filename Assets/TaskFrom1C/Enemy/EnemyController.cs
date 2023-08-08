using DG.Tweening;
using TaskFrom1C.Character;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Enemy
{
    public class EnemyController
    {
        public EnemyView View { get; }
        
        private float _currentHealth;
        private Tween _moveTween;
        
        private readonly EnemyData _enemyData;
        private readonly Transform _target;
        private readonly SignalBus _signalBus;

        public EnemyController(
            EnemyView view,
            EnemyData enemyData,
            Transform target,
            SignalBus signalBus)
        {
            View = Object.Instantiate(view);
            
            _enemyData = enemyData;
            _target = target;
            _signalBus = signalBus;

            _currentHealth = _enemyData.Health;
            
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
            _signalBus.Fire(new CharacterDamageSignal {Damage = 1});
            Death();
        }

        private void Death()
        {
            View.OnTakeBullet -= TakeBullet;
            View.OnTouchBaseLine -= TouchBaseLine;
            
            _moveTween?.Kill();
            _moveTween = null;
            
            Object.Destroy(View);
        }
        
        public class Factory : PlaceholderFactory<EnemyData, Transform, EnemyController>
        { }
    }
}