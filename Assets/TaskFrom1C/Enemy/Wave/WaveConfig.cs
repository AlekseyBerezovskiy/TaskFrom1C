using System;
using UnityEngine;

namespace TaskFrom1C.Enemy
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Config/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        public float MinSpawnsRate;
        public float MaxSpawnsRate;
        public EnemyData EnemyData;
        public int MinEnemyToWin;
        public int MaxEnemyToWin;
    }

    [Serializable]
    public struct EnemyData
    {
        public float MinSpeed;
        public float MaxSpeed;
        public int Health;
        public int Damage;
    }
}