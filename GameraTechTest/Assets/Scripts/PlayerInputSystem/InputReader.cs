using System;
using System.Timers;
using CommunicationSystem;
using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace PlayerInputSystem
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Vector2Channel horizontalMovementInputChannel;

        private Vector2 _frameInput;

        private void Awake()
        {
            _frameInput = Vector2.zero;
        }

        private void Update()
        {
            _frameInput.x = Input.GetAxisRaw("Horizontal");
            _frameInput.y = Input.GetAxisRaw("Vertical");
            
            horizontalMovementInputChannel.SetValue(_frameInput);
        }
    }
}