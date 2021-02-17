using CommunicationSystem.Channels.Events;
using UnityEngine;
using UnityEngine.Events;

namespace CommunicationSystem.Listeners
{
    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel channel;

        [SerializeField] private UnityEvent onEventRaised;

        private void OnEnable()
        {
            if (channel != null)
                channel.Add(Respond);
        }

        private void OnDisable()
        {
            if (channel != null)
                channel.Remove(Respond);
        }

        private void Respond()
        {
            onEventRaised?.Invoke();
        }
    }
}