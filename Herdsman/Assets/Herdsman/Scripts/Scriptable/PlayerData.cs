using Infrastructure.Data.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Data.Scriptable
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Herdsman/Create new PlayerData")]
    public class PlayerData : ScriptableData
    {
        public override string DataPath => "Scriptable/PlayerData";

        public float MoveSpeed;
        public int MaxGroupSize;
        public GameObject PlayerPrefab;
    }
}
