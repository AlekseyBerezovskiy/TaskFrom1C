using System;
using DG.Tweening;
using TaskFrom1C.Character.Bullet;
using TaskFrom1C.Character.Input;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TaskFrom1C.Character
{
    public class CharacterController : ICharacterController, IFixedTickable
    {
        public event Action OnDeath;
        public float CurrentHealth { get; private set; }
        
        private UIHealthBar _uiHealthBar;
        private bool _isReadyToShoot = true;
        
        private readonly CharacterView _view;
        private readonly CharacterConfig _config;
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly BulletView.Factory _bulletFactory;
        private readonly TickableManager _tickableManager;

        private const int PlayerLayerMaskIndex = 3;
        
        public CharacterController(
            CharacterView view,
            CharacterConfig config,
            InputController inputController,
            ISceneObjectStorage sceneObjectStorage,
            BulletView.Factory bulletFactory,
            TickableManager tickableManager)
        {
            _view = view;
            _config = config;
            _sceneObjectStorage = sceneObjectStorage;
            _bulletFactory = bulletFactory;
            _tickableManager = tickableManager;

            CurrentHealth = _config.Health;
            
            _tickableManager.AddFixed(this);
            
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
                Death();
            }
        }

        public void Death()
        {
            _tickableManager.RemoveFixed(this);
            Object.Destroy(_view.gameObject);
        }
        
        public void FixedTick()
        {
            if (_view == null)
            {
                return;
            }
            
            var hit = Physics2D.Raycast(
                _view.transform.position, 
                Vector2.up, 
                _config.BulletData.ShootDistance, 
                PlayerLayerMaskIndex);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Shoot();
                }
            }
        }

        private void Shoot()
        {
            if (_isReadyToShoot)
            {
                _isReadyToShoot = false;
                
                var bulletView = _bulletFactory.Create();
                bulletView.transform.position = _view.ShootTransform.position;

                DOVirtual.DelayedCall(_config.BulletData.ShootRate, () =>
                {
                    _isReadyToShoot = true;
                });
            }
        }

        private void Move(Vector2 direction)
        {
            if (_view == null)
            {
                return;
            }
            
            var charTransform = _view.transform;
            
            charTransform.position =
                Vector3.MoveTowards(
                    charTransform.position, 
                    charTransform.position + (Vector3)direction, 
                    Time.deltaTime * _config.Speed);
        }
    }
}
