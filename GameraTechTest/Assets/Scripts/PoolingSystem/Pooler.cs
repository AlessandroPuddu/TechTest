using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolingSystem
{
    public class Pooler : MonoBehaviour
    {
        private GameObject _prefab;

        private List<GameObject> _pooledObjects;

        private int _startingObjects;
        
        public void Init(GameObject prefab, int startingObjects)
        {
            _startingObjects = startingObjects;
            
            _prefab = prefab;

            _pooledObjects = new List<GameObject>();
        
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            for (int i = 0; i < _startingObjects; i++)
            {
                GameObject pooled = Instantiate(_prefab, this.transform);
            
                _pooledObjects.Add(pooled);
            
                pooled.SetActive(false);
            }
        }

        public GameObject GetPooledObject()
        {
            GameObject pooled = FindInactive();

            if (pooled != null)
            {
                return pooled;
            }
            else
            {
                GenerateObjects();

                pooled = FindInactive();

                return pooled;
            }
        }

        private GameObject FindInactive()
        {
            foreach (GameObject pooled in _pooledObjects)
            {
                if (!pooled.activeInHierarchy)
                    return pooled;
            }

            return null;
        }
    }
}