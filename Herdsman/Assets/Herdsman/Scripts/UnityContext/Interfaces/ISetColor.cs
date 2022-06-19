using Infrastructure.States;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public interface ISetColor
    {
        void SetStateColor(IExitableState state);
    }
}
