using Infrastructure.Data.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Data.Scriptable
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Herdsman/Create new LevelData")]
    public class LevelData : ScriptableData
    {
        public override string DataPath => "Scriptable/LevelData";

        public GameObject LevelPrefab;
    }
}
