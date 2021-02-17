using System.Collections;
using CommunicationSystem.Channels.Variables;
using UnityEngine;
using UnityEngine.AI;

namespace SpawnerSystem
{
    public class FleeBehaviour : MonoBehaviour
    {
        [SerializeField] private TransformChannel playerTransform;
        [SerializeField, Range(0f,10f)] private float targetDistance;
        [SerializeField] private float fleeSpeed;
        
        private NavMeshAgent _navMeshAgent;

        private Coroutine _fleeCoroutine;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void StartFlee()
        {
            if(_fleeCoroutine != null) return;

            _navMeshAgent.speed = fleeSpeed;
            
            _fleeCoroutine = StartCoroutine(WanderCoroutine());
        }
        
        public void StopFlee()
        {
            if(_fleeCoroutine == null) return;
            
            StopCoroutine(_fleeCoroutine);
            _fleeCoroutine = null;
        }

        private IEnumerator WanderCoroutine()
        {
            while (true)
            {
                _navMeshAgent.SetDestination(transform.position + (transform.position - playerTransform.GetValue().position).normalized * targetDistance);

                yield return null;
            }   
        }
    }
}