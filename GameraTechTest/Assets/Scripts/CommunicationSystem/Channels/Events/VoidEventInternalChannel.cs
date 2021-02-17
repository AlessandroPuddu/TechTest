using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommunicationSystem.Channels.Events
{
    [CreateAssetMenu(fileName = "VoidEventInternalChannel", menuName = "CommunicationSystem/Events/Internal/VoidEventInternalChannel", order = 0)]
    public class VoidEventInternalChannel : ScriptableObject
    {
        private readonly Dictionary<Transform, Action> _listeners = new Dictionary<Transform, Action>();

        private void OnDisable()
        {
            _listeners.Clear();
        }

        public void AddListener(Transform listener, Action response)
        {
            if(!_listeners.ContainsKey(listener))
                _listeners.Add(listener,new Action(() => { }));
            
            _listeners[listener] += response;
        }

        public void RemoveListener(Transform listener, Action response)
        {
            if(!_listeners.ContainsKey(listener)) return;
            
            _listeners[listener] -= response;
        }

        public void Notify(Transform listener)
        {
            if(!_listeners.ContainsKey(listener)) return;
            
            _listeners[listener]?.Invoke();
        }
    }
}