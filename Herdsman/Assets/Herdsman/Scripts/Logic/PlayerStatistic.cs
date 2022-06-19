using Herdsman.Data.Scriptable;
using Herdsman.Models;
using Infrastructure.Data.Scriptable;
using System;

namespace Herdsman.Logic
{
    public class PlayerStatistic : IPlayerStatistic
    {
        private readonly GameplayData Gameplay;
        private readonly IGroup Group;

        public event Action<Score> OnScoreChange;

        public bool IsActive { get; private set; }
        private Score CurrentScore { get; set; }

        public PlayerStatistic(IGroup group)
        {
            Gameplay = ScriptableData.Get<GameplayData>();
            Group = group;
        }

        public void Start()
        {
            if (IsActive)
                return;
            Group.OnActorLeave += OnActorLeave;
            IsActive = true;
        }

        public void Stop()
        {
            if (!IsActive)
                return;
            Group.OnActorLeave -= OnActorLeave;
            IsActive = false;
        }

        // events
        private void OnActorLeave(BaseActor actor)
        {
            var intToAdd = Gameplay.ScorePerAnimal;
            CurrentScore += intToAdd;
            OnScoreChange?.Invoke(CurrentScore);
        }
    }
}
