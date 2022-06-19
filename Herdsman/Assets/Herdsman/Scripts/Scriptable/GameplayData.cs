using Infrastructure.Data.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Data.Scriptable
{
    [CreateAssetMenu(fileName = "GameplayData", menuName = "Herdsman/Create new GameplayData")]
    public class GameplayData : ScriptableData
    {
        public override string DataPath => "Scriptable/GameplayData";

        public int AnimalCountAtStart;
        public int MaxAnimalPerLevel;
        public int ScorePerAnimal;
        public float SpawnMinTime;
        public float SpawnMaxTime;
    }
}
