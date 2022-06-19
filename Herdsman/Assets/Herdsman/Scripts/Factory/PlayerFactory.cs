using Herdsman.Data.Scriptable;
using Herdsman.Models;
using Infrastructure.Data.Scriptable;
using Infrastructure.Factory;
using UnityEngine;

namespace Herdsman.Factory
{
    public class PlayerFactory : BaseFactory, IPlayerFactory
    {
        private readonly string CameraPrefabPath = "Common/Camera";

        private PlayerData PlayerData { get; set; }
        private GameObject PlayerObject { get; set; }

        public PlayerFactory()
        {
            PlayerData = ScriptableData.Get<PlayerData>();
        }

        public PlayerActor SpawnPlayer()
        {
            var playerPrefab = PlayerData.PlayerPrefab;
            var moveSpeed = PlayerData.MoveSpeed;
            var maxGroup = PlayerData.MaxGroupSize;
            PlayerObject = Object.Instantiate(playerPrefab);
            var playerActor = new PlayerActor(PlayerObject, moveSpeed, maxGroup);
            return playerActor;
        }

        public GameObject SpawnCamera()
        {
            var cameraPrefab = DataProvider.Load<GameObject>(CameraPrefabPath);
            var camera = Object.Instantiate(cameraPrefab);
            Object.DontDestroyOnLoad(camera);
            return camera;
        }

        public void DestroyPlayer()
        {
            if (PlayerObject != null)
                Object.Destroy(PlayerObject);
        }
    }
}
