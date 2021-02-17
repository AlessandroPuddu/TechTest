using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    public class WanderBehaviour : MonoBehaviour
    {
        [SerializeField, Range(0, 180f)] private float changeDirectionMaxAlpha;
        [SerializeField] private float changeDirectionFrequency;
        [SerializeField, Range(0f,10f)] private float targetDistance;
        
        private NavMeshAgent _navMeshAgent;

        private Coroutine _wanderCoroutine;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void StartWander()
        {
            if(_wanderCoroutine != null) return;
            
            _wanderCoroutine = StartCoroutine(WanderCoroutine());
        }
        
        public void StopWander()
        {
            if(_wanderCoroutine == null) return;
            
            StopCoroutine(_wanderCoroutine);
            _wanderCoroutine = null;
        }

        private IEnumerator WanderCoroutine()
        {
            while (true)
            {
                _navMeshAgent.SetDestination(transform.position + Quaternion.Euler(0f, Random.Range(-changeDirectionMaxAlpha, changeDirectionMaxAlpha), 0f) *
                                             transform.forward * targetDistance);

                yield return new WaitForSeconds(changeDirectionFrequency);
            }   
        }
    }
}