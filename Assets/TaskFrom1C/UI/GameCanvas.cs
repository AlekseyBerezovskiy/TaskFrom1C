using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.UI
{
    public class GameCanvas : SceneObject
    {
        public Canvas Canvas => canvas;
        
        [SerializeField] private Canvas canvas;
    }
}
