using Infrastructure.Data.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Data.Scriptable
{
    [CreateAssetMenu(fileName = "AnimalData", menuName = "Herdsman/Create new AnimalData")]
    public class AnimalData : ScriptableData
    {
        public override string DataPath => "Scriptable/AnimalData";

        public float MoveSpeed;
        public Vector2 PatrolSwitchTime;
        public GameObject AnimalPrefab;
    }
}
