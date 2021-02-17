using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace CommunicationSystem.Setters
{
    public class TransformChannelSetter : MonoBehaviour
    {
        [SerializeField] private TransformChannel toSet;

        private void Awake()
        {
            toSet.SetValue(transform);
        }
    }
}