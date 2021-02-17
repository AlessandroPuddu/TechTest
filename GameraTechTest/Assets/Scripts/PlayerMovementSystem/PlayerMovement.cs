using System;
using CommunicationSystem;
using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace PlayerMovementSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Vector2Channel horizontalMovementInputChannel;
        [SerializeField] private TransformChannel cameraTransform;

        [SerializeField] private bool cameraRelativeMovement;
        [SerializeField] private float speed;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 direction = cameraRelativeMovement ? GetDirectionCameraRelative() : GetDirectionPlain();
            
            _rigidbody.velocity = direction * speed;
            
            if(direction.magnitude <= Mathf.Epsilon) return;
            
            _rigidbody.MoveRotation(Quaternion.LookRotation(_rigidbody.velocity,Vector3.up));
        }

        private Vector3 GetDirectionPlain()
        {
            return new Vector3(horizontalMovementInputChannel.GetValue().x, 0f,
                horizontalMovementInputChannel.GetValue().y).normalized;
        }

        private Vector3 GetDirectionCameraRelative()
        {
            Vector3 direction = cameraTransform.GetValue().right * horizontalMovementInputChannel.GetValue().x +
                                cameraTransform.GetValue().forward * horizontalMovementInputChannel.GetValue().y;

            return Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
        }
    }
}