using System.Collections.Generic;
using UnityEngine;

namespace PoolingSystem
{
    [CreateAssetMenu(menuName = "Managers/PoolersManager", fileName = "PoolersManager", order = 1)]
    public class PoolersManager : ScriptableObject
    {
        [SerializeField]
        private int startingPooledObjects = 0;

        private readonly Dictionary<GameObject, Pooler> _poolers = new Dictionary<GameObject, Pooler>();

        public Pooler GetPooler(GameObject prefab)
        {
            if (!_poolers.ContainsKey(prefab))
            {
                GameObject pooler = new GameObject {name = prefab.name + "Pooler"};
                
                Pooler poolerComponent = pooler.AddComponent<Pooler>();
                
                poolerComponent.Init(prefab,startingPooledObjects);
                
                _poolers.Add(prefab,poolerComponent);

                return poolerComponent;
            }
            else
            {
                return _poolers[prefab];
            }
        }
    }
}