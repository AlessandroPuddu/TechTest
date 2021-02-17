using CommunicationSystem.Channels.Variables;
using UnityEngine;

namespace CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private TransformChannel target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;

        private void LateUpdate()
        {
            Vector3 targetFacing = (target.GetValue().position - transform.position).normalized;
            Vector3 targetPosition = target.GetValue().position + offset;

            transform.forward = Vector3.Lerp(transform.forward, targetFacing, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}