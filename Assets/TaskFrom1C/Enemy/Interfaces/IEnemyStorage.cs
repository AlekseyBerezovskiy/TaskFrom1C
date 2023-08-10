using System.Collections.Generic;

namespace TaskFrom1C.Enemy
{
    public interface IEnemyStorage
    {
        void AddEnemy(EnemyController enemyController);
        List<EnemyController> GetAllEnemy();
        void DeleteEnemy(int instanceID);
    }
}