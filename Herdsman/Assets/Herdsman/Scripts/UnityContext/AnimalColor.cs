using Herdsman.Logic;
using Infrastructure.States;
using UnityEngine;

namespace Herdsman.UnityContext
{
    [RequireComponent(typeof(MeshRenderer))]
    public class AnimalColor : MonoBehaviour, ISetColor
    {
        private readonly string ColorID = "_Color";

        private MeshRenderer meshRenderer;
        private MeshRenderer MeshRenderer
        {
            get
            {
                if (meshRenderer == null)
                    meshRenderer = GetComponent<MeshRenderer>();
                return meshRenderer;
            }
        }

        public void SetStateColor(IExitableState state)
        {
            if (state.GetType() == typeof(IdleState))
                MeshRenderer.material.SetColor(ColorID, Color.green);
            else if (state.GetType() == typeof(PatrolState))
            {
                var patrolState = state as PatrolState;
                if (patrolState.IsIsYard)
                    MeshRenderer.material.SetColor(ColorID, Color.blue);
                else
                    MeshRenderer.material.SetColor(ColorID, Color.red);
            }    
            else if (state.GetType() == typeof(GroupState))
                MeshRenderer.material.SetColor(ColorID, Color.yellow);
        }
    }
}
