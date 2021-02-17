using System.Collections;
using System.Collections.Generic;
using PoolingSystem.Interfaces;
using UnityEngine;

namespace PoolingSystem
{
    public class Pooler : MonoBehaviour, IPooler
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

        public void DeactivatePooledObject(GameObject pooled)
        {
            if(!_pooledObjects.Contains(pooled))
                return;
        
            pooled.transform.position = Vector3.zero;
            pooled.SetActive(false);
        }
    
        /// <summary>
        /// Get a pooled object and starts a coroutine that
        /// deactivate the pooled object after timeToLive seconds
        /// </summary>
        /// <param name="timeToLive">Liftetime of the object</param>
        /// <returns>The pooled object</returns>
        public GameObject GetPooledObject(float timeToLive)
        {
            GameObject pooled = FindInactive();

            if (pooled != null)
            {
                StartCoroutine(PooledObjectLifetime(pooled, timeToLive));
            
                return pooled;
            }
            else
            {
                GenerateObjects();

                pooled = FindInactive();

                StartCoroutine(PooledObjectLifetime(pooled, timeToLive));
            
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

        private IEnumerator PooledObjectLifetime(GameObject pooled,float duration)
        {
            yield return new WaitForSeconds(duration);
        
            DeactivatePooledObject(pooled);
        }
    }
}