using Herdsman.Models;
using UnityEngine;

namespace Herdsman.Factory
{
    public interface IAnimalFactory
    {
        AnimalActor SpawnAnimal(Vector3 position);
    }
}
