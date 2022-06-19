using System.Collections;
using System.Collections.Generic;
using Herdsman.Models;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public class CollisionDetector : MonoBehaviour, ISetPlayer
    {
        private PlayerActor Player { get; set; }

        public void SetPlayer(PlayerActor player) => Player = player;

        private void OnTriggerEnter(Collider other)
        {
            var collideObject = other.gameObject;
            var collideInteractor = collideObject.GetComponent<ICollideWithPlayer>();
            collideInteractor?.ColliderWithPlayer(Player);
        }
    }
}
