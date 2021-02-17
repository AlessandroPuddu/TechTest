using UnityEngine;

namespace CommunicationSystem
{
    public class Vector2Channel : AbstractChannel<Vector2>
    {
        protected override void Add(Vector2 toAdd) => value += toAdd;
        protected override void Remove(Vector2 toRemove) => value -= toRemove;
    }
}