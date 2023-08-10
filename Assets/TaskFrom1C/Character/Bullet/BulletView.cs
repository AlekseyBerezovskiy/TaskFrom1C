using DG.Tweening;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Character.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private float _speed;
        private Tween _moveTween;

        private const float TargetPosY = 15f;
        
        public void Destroy()
        {
            _moveTween?.Kill();
            Destroy(gameObject);
        }
        
        [Inject]
        private void Inject(CharacterConfig characterConfig)
        {
            _speed = characterConfig.BulletData.Speed;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var target = transform.position.y + TargetPosY;
            
            _moveTween = transform.DOMoveY(
                    target,
                    Mathf.Abs(transform.position.y - target) / _speed)
                .SetEase(Ease.Linear)
                .OnComplete(Destroy);
        }

        public class Factory : PlaceholderFactory<BulletView>
        { }
    }
}