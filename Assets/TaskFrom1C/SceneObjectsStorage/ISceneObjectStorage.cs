using System;
using UnityEngine;

namespace TaskFrom1C.SceneObjectsStorage
{
    public interface ISceneObjectStorage : IDisposable
    {
        void Add<T>(SceneObject sceneObject) where T : SceneObject;
        T CreateFromResourcesAndAdd<T>(string source, Transform parent = null) where T : SceneObject; 
        void Destroy<T>() where T : SceneObject;
        T Get<T>() where T : SceneObject;
    }
}