using System;
using System.Collections;
using PoolingSystem;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject pickupPrefab;

        [SerializeField] private float minWait;
        [SerializeField] private float maxWait;

        [SerializeField] private PoolersManager poolersManager;

        [SerializeField] private int singleSpawn;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                Spawn(singleSpawn);
                
                yield return new WaitForSeconds(Random.Range(minWait,maxWait));
            }
        }

        public void Spawn(int toSpawn)
        {
            GameObject p = poolersManager.GetPooler(pickupPrefab).GetPooledObject();

            p.transform.position = transform.position + Vector3.right * Random.Range(-5, 5) +
                                   Vector3.forward * Random.Range(-5, 5);

            p.SetActive(true);   
        }
    }
}