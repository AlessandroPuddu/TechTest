using System;
using AI;
using UnityEngine;

namespace SpawnerSystem
{
    public class SpawnerAI : MonoBehaviour
    {
        private Fsm _fsm;

        private void Awake()
        {
            FsmState wander = new FsmState();
            FsmState flee = new FsmState();

            _fsm = new Fsm(wander);
        }
    }
}