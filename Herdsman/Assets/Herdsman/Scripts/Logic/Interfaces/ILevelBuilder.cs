
using UnityEngine;

namespace Herdsman.Logic
{
    public interface ILevelBuilder : IBuilder
    {
        Vector3 Center { get; }

        void Scan();

        void DestroyLevel();
    }
}
