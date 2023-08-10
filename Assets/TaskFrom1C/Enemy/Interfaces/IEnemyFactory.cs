using UnityEngine;

namespace TaskFrom1C.Enemy
{
    public interface IEnemyFactory
    {
        EnemyController Create(Transform parent);
    }
}