

using Infrastructure.UnityContext;

namespace Herdsman.Logic
{
    public abstract class MovementSystem
    {
        private readonly IUpdateLoop Updater;

        public MovementSystem(IUpdateLoop updateLoop)
        {
            Updater = updateLoop;
        }


    }
}
