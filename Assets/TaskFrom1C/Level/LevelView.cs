using System;
using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.Level
{
    public class LevelView : SceneObject
    {
        public SpawnpointData[] SpawnpointDatas => spawnpointDatas;
        
        [SerializeField] private SpawnpointData[] spawnpointDatas;
    }

    [Serializable]
    public struct SpawnpointData
    {
        public Transform Spawnpoint;
        public Transform Target;
    }
}