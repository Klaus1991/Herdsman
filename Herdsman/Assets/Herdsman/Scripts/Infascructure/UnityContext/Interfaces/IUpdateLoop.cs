using System;

namespace Infrastructure.UnityContext
{
    public interface IUpdateLoop
    {
        event Action OnUpdate;
    }
}
