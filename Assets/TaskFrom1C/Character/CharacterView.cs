using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.Character
{
    public class CharacterView : SceneObject
    {
        public Transform ShootTransform => shootTransform;
        
        [SerializeField] private Transform shootTransform;
    }
}