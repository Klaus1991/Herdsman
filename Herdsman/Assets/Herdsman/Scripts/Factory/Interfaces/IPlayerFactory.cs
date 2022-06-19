
using Herdsman.Models;
using UnityEngine;

namespace Herdsman.Factory
{
    public interface IPlayerFactory
    {
        PlayerActor SpawnPlayer();

        GameObject SpawnCamera();

        void DestroyPlayer();
    }
}
