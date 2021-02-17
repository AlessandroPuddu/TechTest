using UnityEngine;

namespace CommunicationSystem
{
    public abstract class AbstractChannel<T> : ScriptableObject
    {
        [SerializeField] protected T value;

        public virtual T GetValue() => value;
        public virtual void SetValue(T newValue) => value = newValue;
        public abstract void Add(T toAdd);
        public abstract void Remove(T toRemove);
    }
}
