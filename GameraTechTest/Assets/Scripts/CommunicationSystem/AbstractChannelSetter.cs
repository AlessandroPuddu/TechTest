using UnityEngine;

namespace CommunicationSystem
{
    public abstract class AbstractChannelSetter<TChannel,TValue> : MonoBehaviour
        where TChannel : AbstractChannel<TValue>
    {
        [SerializeField] private TChannel toSet;

        private void Awake()
        {
            toSet.SetValue(GetValue());
        }

        protected abstract TValue GetValue();
    }
}