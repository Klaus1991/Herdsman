
using Herdsman.Data.Scriptable;
using Herdsman.UnityContext;
using Infrastructure.Data.Scriptable;
using Unity.AI.Navigation;
using UnityEngine;

namespace Herdsman.Logic
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly LevelData Data;

        private GameObject LevelObject { get; set; }
        private NavMeshSurface NavData { get; set; }

        public Vector3 Center { get; private set; }

        public LevelBuilder()
        {
            Data = ScriptableData.Get<LevelData>();
        }

        public void Build()
        {
            var levelPrefab = Data.LevelPrefab;
            LevelObject = Object.Instantiate(levelPrefab);
            NavData = LevelObject.GetComponent<NavMeshSurface>();
            var field = LevelObject.GetComponentInChildren<Field>();
            Center = field.Center;
        }

        public void Scan()
        {
            if (NavData == null)
                return;
            NavData.BuildNavMesh();
        }

        public void Dispose()
        {
            DestroyLevel();
        }

        public void DestroyLevel()
        {
            if (LevelObject != null)
                GameObject.Destroy(LevelObject);
        }
    }
}
