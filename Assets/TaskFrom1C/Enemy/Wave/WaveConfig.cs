using System;
using UnityEngine;

namespace TaskFrom1C.Enemy
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Config/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        public float SpawnsRate;
        public EnemyData EnemyData;
    }

    [Serializable]
    public struct EnemyData
    {
        public float Speed;
        public int Health;
        public int Damage;
    }
}