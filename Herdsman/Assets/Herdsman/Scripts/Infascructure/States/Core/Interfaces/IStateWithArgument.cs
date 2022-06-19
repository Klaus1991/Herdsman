using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.States
{
    public interface IStateWithArgument<TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}
