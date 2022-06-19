
using Herdsman.Factory;
using System;

namespace Herdsman.Logic
{
    public class GameSetup : IBuilder
    {
        private readonly IPlayerFactory PlayerFactory;

        public GameSetup(IPlayerFactory playerFactory)
        {
            PlayerFactory = playerFactory;
        }

        public void Build()
        {
            PlayerFactory.SpawnCamera();
        }

        public void Dispose() { }
    }
}
