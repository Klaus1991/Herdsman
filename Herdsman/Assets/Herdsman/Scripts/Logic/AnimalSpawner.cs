using Herdsman.Data.Scriptable;
using Herdsman.Factory;
using Herdsman.Models;
using Herdsman.Utils;
using Infrastructure.Data.Scriptable;
using Infrastructure.UnityContext;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Logic
{
    public class AnimalSpawner : IAnimalSpawner
    {
        private readonly IAnimalFactory AnimalFactory;
        private readonly GameplayData Gameplay;
        private readonly Vector3 Center;
        private readonly float SpawnRadius = 15f;
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly int MaxCount;

        public List<AnimalActor> Animals { get; private set; }

        private int AnimalsCount { get; set; }
        private Coroutine LoopCoroutine { get; set; }

        public AnimalSpawner(ICoroutineRunner coroutineRunner, IAnimalFactory animalFactory, Vector3 center)
        {
            CoroutineRunner = coroutineRunner;
            AnimalFactory = animalFactory;
            Gameplay = ScriptableData.Get<GameplayData>();
            Center = center;
            MaxCount = Gameplay.MaxAnimalPerLevel;
            Animals = new List<AnimalActor>();
        }

        public void Spawn()
        {
            // spawn at start
            var animalCount = Gameplay.AnimalCountAtStart;
            SpawnAnimal(animalCount);
            // start spawn loop
            LoopCoroutine = CoroutineRunner.StartCoroutine(SpawnLoop());
        }

        private void SpawnAnimal(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnAnimal();
            }
        }

        private void SpawnAnimal()
        {
            var areaToSpawn = NavmeshUtils.FieldArea;
            var spawnPosition = NavmeshUtils.RandomNavmeshLocation(Center, SpawnRadius, areaToSpawn);
            var animal = AnimalFactory.SpawnAnimal(spawnPosition);
            animal.EnterState<IdleState>();
            AnimalsCount++;
            Animals.Add(animal);
        }

        private IEnumerator SpawnLoop()
        {
            while (AnimalsCount < MaxCount)
            {
                var spawnDelay = Random.Range(Gameplay.SpawnMinTime, Gameplay.SpawnMaxTime);
                yield return new WaitForSeconds(spawnDelay);
                SpawnAnimal();
            }
        }

        public void Dispose()
        {
            if (LoopCoroutine != null)
                CoroutineRunner.StopCoroutine(LoopCoroutine);
        }
    }
}
