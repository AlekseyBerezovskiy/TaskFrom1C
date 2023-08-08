using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.Level
{
    public class LevelView : SceneObject
    {
        public Transform[] Spawnpoints => spawnpoints;
        
        [SerializeField] private Transform[] spawnpoints;
    }
}