using UnityEngine;

namespace PickupSystem
{ 
    public class PickupTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IGatherPickups>() == null) return;
            
            gameObject.SetActive(false);
        }
    }
}