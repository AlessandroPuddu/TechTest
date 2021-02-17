using UnityEngine;

namespace CommunicationSystem
{
    public abstract class AbstractChannel<T> : ScriptableObject
    {
        [SerializeField] protected T value;

        protected virtual T GetValue() => value;
        protected virtual void SetValue(T newValue) => value = newValue;
        protected abstract void Add(T toAdd);
        protected abstract void Remove(T toRemove);
    }
}
