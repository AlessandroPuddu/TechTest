using System;
using UnityEngine;

namespace Animations
{
    public class RotationBehaviour : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        
        private void Update()
        {
            float rotation = 6.0f * rotationSpeed * Time.deltaTime;
            
            transform.Rotate(rotation,rotation,rotation);
        }
    }
}