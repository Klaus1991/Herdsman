using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Logic
{
    public interface IMovable
    {
        Vector3 Position { get; }

        void MoveTo(Vector3 position);
    }
}
