using UnityEngine;

namespace CommunicationSystem.Channels.Variables
{
    [CreateAssetMenu(menuName = "CommunicationSystem/Variables/Vector2Channel", fileName = "Vector2Channel", order = 1)]
    public class Vector2Channel : AbstractChannel<Vector2>
    {
        public override void Add(Vector2 toAdd) => value += toAdd;
        public override void Remove(Vector2 toRemove) => value -= toRemove;
    }
}