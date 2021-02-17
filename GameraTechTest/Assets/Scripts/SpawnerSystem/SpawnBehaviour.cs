using System;
using System.Collections;
using PoolingSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject pickupPrefab;

        [SerializeField] private float minWait;
        [SerializeField] private float maxWait;

        [SerializeField] private PoolersManager poolersManager;

        private void Start()
        {
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            while (true)
            {
                GameObject p = poolersManager.GetPooler(pickupPrefab).GetPooledObject();

                p.transform.position = transform.position + Vector3.up * 2 + Vector3.right * Random.Range(-5, 5) +
                                       Vector3.forward * Random.Range(-5, 5);

                p.SetActive(true);
                
                yield return new WaitForSeconds(2f);
            }
        }
    }
}