using System;

namespace TaskFrom1C.Character
{
    public interface ICharacterController
    {
        event Action OnDeath;
        float CurrentHealth { get; }
        void TakeDamage(float damage);
        void Death();
    }
}