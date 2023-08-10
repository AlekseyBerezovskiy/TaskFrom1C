namespace TaskFrom1C.Enemy
{
    public interface IEnemyStorage
    {
        void AddEnemy(EnemyController enemyController);
        EnemyController GetEnemy(int instanceID);
        void DeleteEnemy(int instanceID);
    }
}