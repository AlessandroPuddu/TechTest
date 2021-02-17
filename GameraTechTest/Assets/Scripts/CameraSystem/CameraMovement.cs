using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private TransformChannel target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;

        private void Start()
        {
            MoveInstant();
        }

        private void LateUpdate()
        {
            MoveLerp();    
        }

        private void MoveLerp()
        {
            Vector3 targetFacing = (target.GetValue().position - transform.position).normalized;
            Vector3 targetPosition = target.GetValue().position + offset;

            transform.forward = Vector3.Lerp(transform.forward, targetFacing, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }

        private void MoveInstant()
        {
            Vector3 targetFacing = (target.GetValue().position - transform.position).normalized;
            Vector3 targetPosition = target.GetValue().position + offset;

            transform.forward = targetFacing;
            transform.position = targetPosition;    
        }
    }
}