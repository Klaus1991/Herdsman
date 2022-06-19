using Herdsman.Data.Scriptable;
using Herdsman.Models;
using Infrastructure.Data.Scriptable;
using Infrastructure.Factory;
using UnityEngine;

namespace Herdsman.Factory
{
    public class AnimalFactory : BaseFactory, IAnimalFactory
    {
        private readonly AnimalData AnimalData;

        public AnimalFactory()
        {
            AnimalData = ScriptableData.Get<AnimalData>();
        }

        public AnimalActor SpawnAnimal(Vector3 position)
        {
            var animalPrefab = AnimalData.AnimalPrefab;
            var moveSpeed = AnimalData.MoveSpeed;
            var patrolTime = AnimalData.PatrolSwitchTime;
            var animalObject = Object.Instantiate(animalPrefab);
            animalObject.transform.position = position;
            var animalActor = new AnimalActor(animalObject, moveSpeed, patrolTime);
            return animalActor;
        }
    }
}
