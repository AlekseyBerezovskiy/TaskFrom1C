using System;
using UnityEngine;

namespace TaskFrom1C.Character
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Config/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float Speed;
        public int Health;
        public BulletData BulletData;
    }

    [Serializable]
    public struct BulletData
    {
        public int Damage;
        public float Speed;
    }
}