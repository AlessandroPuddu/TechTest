using System.Collections;
using AI;
using CommunicationSystem.Channels.Events;
using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace SpawnerSystem
{
    public class SpawnerAI : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel onWanderEnter;
        [SerializeField] private VoidEventChannel onFleeEnter;

        [SerializeField] private TransformChannel playerTransform;

        [SerializeField] private float fleeDistance;
        [SerializeField] private float wanderDistance;

        [SerializeField] private float fsmResolution;
        
        private Fsm _fsm;

        private void Awake()
        {
            FsmState wander = new FsmState();
            FsmState flee = new FsmState();

            FsmTransition t1 = new FsmTransition(PlayerNear);
            FsmTransition t2 = new FsmTransition(PlayerFar);
            
            wander.AddTransition(t1,flee);
            flee.AddTransition(t2,wander);
            
            wander.enterActions.Add(() => onWanderEnter.GetValue()?.Invoke());
            flee.enterActions.Add(() => onFleeEnter.GetValue()?.Invoke());

            _fsm = new Fsm(wander);
        }

        private void Start()
        {
            StartCoroutine(UpdateFsm());
        }

        private bool PlayerNear()
        {
            return Vector3.Distance(transform.position, playerTransform.GetValue().position) <= fleeDistance;
        }

        private bool PlayerFar()
        {
            return Vector3.Distance(transform.position, playerTransform.GetValue().position) >= wanderDistance;
        }

        private IEnumerator UpdateFsm()
        {
            while (true)
            {
                _fsm.UpdateFsm();

                yield return new WaitForSeconds(fsmResolution);
            }
        }
    }
}