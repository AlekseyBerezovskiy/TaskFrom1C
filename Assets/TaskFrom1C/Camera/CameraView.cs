using TaskFrom1C.SceneObjectsStorage;
using UnityEngine;

namespace TaskFrom1C.Camera
{
    public class CameraView : SceneObject
    {
        public UnityEngine.Camera Camera => camera;
    
        [SerializeField] private UnityEngine.Camera camera;
    }
}
