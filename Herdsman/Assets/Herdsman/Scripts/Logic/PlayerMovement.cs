using Herdsman.Models;
using Herdsman.Services;
using System;
using UnityEngine;

namespace Herdsman.Logic
{
    public class PlayerMovement : IProcess, IDisposable
    {
        private readonly IMovable Target;
        private readonly Camera Camera;
        private readonly IPlayerInput Input;

        public bool IsActive { get; private set; }

        public PlayerMovement(IMovable target, IPlayerInput playerInput)
        {
            Target = target;
            Input = playerInput;
            Camera = Camera.main;
        }

        public void Dispose()
        {
            Stop();
        }

        public void Start()
        {
            if (IsActive)
                return;
            IsActive = true;
            Input.OnClickEvent += OnClick;
        }

        public void Stop()
        {
            if (!IsActive)
                return;
            IsActive = false;
            Input.OnClickEvent -= OnClick;
        }

        private GameObject GetRayTarget(Vector2 mousePosition, out Vector3 hitPosition)
        {
            Ray ray = Camera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hitPosition = hit.point;
                return hit.collider.gameObject;
            }
            hitPosition = Vector3.zero;
            return null;
        }

        // events
        private void OnClick(Vector2 position)
        {
            Vector3 hitPosition = Vector3.zero;
            var rayTarget = GetRayTarget(position, out hitPosition);
            if (rayTarget != null)
                Target?.MoveTo(hitPosition);
        }
    }
}
