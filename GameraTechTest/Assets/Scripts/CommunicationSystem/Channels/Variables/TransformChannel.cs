using UnityEngine;

namespace CommunicationSystem.Channels.Variables
{
    [CreateAssetMenu(menuName = "CommunicationSystem/Variables/TransformChannel", fileName = "TransformChannel", order = 1)]
    public class TransformChannel : AbstractChannel<Transform>
    {
        public override void Add(Transform toAdd)
        {
        }

        public override void Remove(Transform toRemove)
        {
        }
    }
}