
using System;

namespace Infrastructure.States
{
    public interface INextState
    {
        event Action OnNextState;
    }
}
