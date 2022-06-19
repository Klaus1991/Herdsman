
using Herdsman.Factory;
using Herdsman.Models;
using Herdsman.Services;
using Herdsman.UnityContext;
using Infrastructure.Models;
using Infrastructure.UnityContext;
using Infrastructure.UnityContext.Components;
using System;

namespace Herdsman.Logic
{
    public class Game : IGameBuilder
    {
        public event Action OnNextState;

        private readonly IHudFactory UIFactory;
        private readonly IPlayerFactory PlayerFactory;
        private readonly IAnimalFactory AnimalFactory;
        private readonly ILevelBuilder LevelBuilder;
        private readonly IPlayerInput Input;
        private readonly ISetTarget Camera;
        private readonly IAnimalSpawner AnimalSpawner;
        private readonly ICoroutineRunner CoroutineRunner;
        
        private IProcess PlayerMovement { get; set; }
        private IPlayerStatistic Statistics { get; set; }
        private PlayerActor Player { get; set; }
        private IHide GameUI { get; set; }

        public Game(ICoroutineRunner coroutineRunner, IHudFactory uiFactory, IPlayerFactory playerFactory, IAnimalFactory animalFactory, IPlayerInput playerInput)
        {
            UIFactory = uiFactory;
            PlayerFactory = playerFactory;
            AnimalFactory = animalFactory;
            CoroutineRunner = coroutineRunner;
            Input = playerInput;
            LevelBuilder = new LevelBuilder();
            AnimalSpawner = new AnimalSpawner(CoroutineRunner, AnimalFactory, LevelBuilder.Center);
            Camera = ComponentLocator.Get<CameraFollow>();
        }

        public void Build()
        {
            BuildLevel();
            BuildPlayer();
            BuildAnimals();
            BuildUI();
        }

        private void BuildLevel()
        {
            LevelBuilder.Build();
            LevelBuilder.Scan();
        }

        private void BuildPlayer()
        {
            Player = PlayerFactory.SpawnPlayer();
            Camera.SetTarget(Player.View.transform);
            PlayerMovement = new PlayerMovement(Player, Input);
            PlayerMovement.Start();
        }

        private void BuildUI()
        {
            Statistics = new PlayerStatistic(Player);
            Statistics.Start();
            GameUI = UIFactory.ShowScoreUI(Statistics);
        }

        private void BuildAnimals()
        {
            AnimalSpawner.Spawn();
        }

        public void Dispose()
        {
            PlayerMovement?.Stop();
            Statistics?.Stop();
            GameUI?.Hide();
            LevelBuilder?.Dispose();
            AnimalSpawner?.Dispose();
            PlayerFactory.DestroyPlayer();
        }
    }
}
