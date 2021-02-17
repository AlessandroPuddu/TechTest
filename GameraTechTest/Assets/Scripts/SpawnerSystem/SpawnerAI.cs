using System.Collections;
using AI;
using CommunicationSystem.Channels.Events;
using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace SpawnerSystem
{
    public class SpawnerAI : MonoBehaviour
    {
        [SerializeField] private VoidEventInternalChannel onWanderEnter;
        [SerializeField] private VoidEventInternalChannel onWanderExit;
        [SerializeField] private VoidEventInternalChannel onFleeEnter;
        [SerializeField] private VoidEventInternalChannel onFleeExit;

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
            
            wander.enterActions.Add(() => onWanderEnter.Notify(transform.root));
            wander.exitActions.Add(() => onWanderExit.Notify(transform.root));
            
            flee.enterActions.Add(() => onFleeEnter.Notify(transform.root));
            flee.exitActions.Add(() => onFleeExit.Notify(transform.root));

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