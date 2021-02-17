using System;
using CommunicationSystem;
using UnityEngine;

namespace PlayerMovementSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Vector2Channel horizontalMovementInputChannel;
        [SerializeField] private float speed;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 direction = new Vector3(horizontalMovementInputChannel.GetValue().x, 0f,
                horizontalMovementInputChannel.GetValue().y);
            
            _rigidbody.velocity = direction.normalized * speed;
            _rigidbody.MoveRotation(Quaternion.LookRotation(_rigidbody.velocity,Vector3.up));
        }
    }
}