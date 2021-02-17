using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace CommunicationSystem.Setters
{
    public class TransformChannelSetter : AbstractChannelSetter<TransformChannel,Transform>
    {
        protected override Transform GetValue() => transform;
    }
}