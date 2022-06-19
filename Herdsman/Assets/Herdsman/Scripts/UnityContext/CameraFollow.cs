using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public class CameraFollow : MonoBehaviour, ISetTarget
    {
        [SerializeField]
        private float YOffset;
        [SerializeField]
        private float XOffset;
        [SerializeField]
        private float Smooth;

        private Transform Target { get; set; }

        public void SetTarget(Transform target) => Target = target;

        private void LateUpdate()
        {
            if (Target == null)
                return;
            var targetPosition = Target.position;
            targetPosition.y += YOffset;
            targetPosition.x += XOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * Smooth);
        }
    }
}

