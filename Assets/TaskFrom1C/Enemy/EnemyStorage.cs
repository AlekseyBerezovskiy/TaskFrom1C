using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TaskFrom1C.Enemy
{
    public class EnemyStorage : IEnemyStorage
    {
        private Dictionary<int, EnemyController> _storage = new Dictionary<int, EnemyController>();
        
        public void AddEnemy(EnemyController enemyController)
        {
            var instanceId = enemyController.View.GetInstanceID();
            
            if (_storage.ContainsKey(instanceId))
            {
                Debug.LogError($"Enemy with Id={instanceId} has been added!");
                return;
            }
            
            _storage.Add(instanceId, enemyController);
        }

        public List<EnemyController> GetAllEnemy()
        {
            return _storage.Values.ToList();
        }

        public void DeleteEnemy(int instanceID)
        {
            if (_storage.ContainsKey(instanceID))
            {
                _storage.Remove(instanceID);
            }
        }
    }
}