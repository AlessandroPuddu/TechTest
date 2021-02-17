using System;
using System.Collections;
using UnityEngine;

namespace Animations
{
    public class ScalingBehaviour : MonoBehaviour
    {
        [SerializeField] private float scalingSpeed;
        
        private void OnEnable()
        {
            StartCoroutine(ScalingCoroutine());
        }

        private IEnumerator ScalingCoroutine()
        {
            transform.localScale = new Vector3(0.1f, 0.1f,0.1f);

            float timer = 0f;
            
            while (timer * scalingSpeed <= 1f)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, timer * scalingSpeed);

                yield return null;
                
                timer += Time.deltaTime;
            }
        }
    }
}