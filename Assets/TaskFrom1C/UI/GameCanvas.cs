using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.UI
{
    public class GameCanvas : SceneObject
    {
        public Canvas Canvas => canvas;
        public RectTransform Container => container;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform container;
    }
}
