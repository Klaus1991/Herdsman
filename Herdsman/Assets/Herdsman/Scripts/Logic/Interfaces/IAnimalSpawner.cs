using Herdsman.Models;
using System;
using System.Collections.Generic;

namespace Herdsman.Logic
{
    public interface IAnimalSpawner : ISpawn, IDisposable
    {
        List<AnimalActor> Animals { get; }
    }
}


