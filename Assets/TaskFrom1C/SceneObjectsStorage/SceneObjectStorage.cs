using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TaskFrom1C.SceneObjectsStorage
{
    public class SceneObjectStorage : ISceneObjectStorage
    {
        private Dictionary<Type, SceneObject> _sceneObjectsStorage = new Dictionary<Type, SceneObject>();

        public void Add<T>(SceneObject sceneObject) where T : SceneObject
        {
            var type = typeof(T);

            if (CheckToContainsForAdd(type))
            {
                _sceneObjectsStorage.Add(type, sceneObject);
            }
        }

        public T CreateFromResourcesAndAdd<T>(string source, Transform parent = null) where T : SceneObject
        {
            var type = typeof(T);

            if (CheckToContainsForAdd(type))
            {
                var prefab = Resources.Load<T>(source);
                if (prefab != null)
                {
                    var obj = Object.Instantiate(prefab);

                    if (parent != null)
                    {
                        obj.transform.SetParent(parent);
                    }

                    _sceneObjectsStorage.Add(type, obj);

                    return obj;
                }

                Debug.LogError($"Prefab from {source} not found!");
            }

            return null;
        }

        public void Destroy<T>() where T : SceneObject
        {
            var type = typeof(T);

            if (CheckToContainsForGet(type))
            {
                Object.Destroy(_sceneObjectsStorage[type]);
                _sceneObjectsStorage.Remove(type);
            }
        }

        public T Get<T>() where T : SceneObject
        {
            var type = typeof(T);

            if (CheckToContainsForGet(type))
            {
                return _sceneObjectsStorage[type].GetComponent<T>();
            }

            return null;
        }

        public void Dispose()
        {
            _sceneObjectsStorage.Clear();
            _sceneObjectsStorage = null;
        }

        private bool CheckToContainsForAdd(Type type)
        {
            if (!_sceneObjectsStorage.ContainsKey(type))
            {
                return true;
            }

            Debug.LogError(type + " has been added!");
            return false;
        }

        private bool CheckToContainsForGet(Type type)
        {
            if (_sceneObjectsStorage.ContainsKey(type))
            {
                return true;
            }

            Debug.LogError(type + " was not found!");
            return false;
        }
    }
}