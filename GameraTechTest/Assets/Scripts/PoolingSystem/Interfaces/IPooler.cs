using UnityEngine;

namespace PoolingSystem.Interfaces
{
    public interface IPooler
    {
        GameObject GetPooledObject();
        void DeactivatePooledObject(GameObject pooledObject);
    }
}