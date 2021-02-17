using CommunicationSystem.Channels.Events;
using UnityEngine;
using UnityEngine.Events;

namespace CommunicationSystem.Listeners
{
    public class VoidEventInternalListener : MonoBehaviour
    {
        [SerializeField] private VoidEventInternalChannel channel;

        [SerializeField] private UnityEvent onEventRaised;

        private void OnEnable()
        {
            if (channel != null)
                channel.AddListener(transform.root,Respond);
        }

        private void OnDisable()
        {
            if (channel != null)
                channel.RemoveListener(transform.root,Respond);
        }

        private void Respond()
        {
            onEventRaised?.Invoke();
        }
    }
}