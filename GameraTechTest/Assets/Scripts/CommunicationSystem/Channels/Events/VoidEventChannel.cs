using UnityEngine;
using UnityEngine.Events;

namespace CommunicationSystem.Channels.Events
{
    [CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Channels/Events/VoidEventChannel", order = 0)]
    public class VoidEventChannel : AbstractChannel<UnityAction>
    {
        public override void Add(UnityAction toAdd)
        {
            value += toAdd;
        }

        public override void Remove(UnityAction toRemove)
        {
            value -= toRemove;
        }

        public override void SetValue(UnityAction newValue)
        {
        }
    }
}