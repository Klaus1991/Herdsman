using Herdsman.Models;
using Infrastructure.Models;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Herdsman.Logic.UI
{
    public class ScoreUI : MonoBehaviour, IShowWithArgs<IHide, IPlayerStatistic>, IHide
    {
        [SerializeField]
        private Text Label;

        private IPlayerStatistic PlayerStatistic { get; set; }

        public void Hide()
        {
            PlayerStatistic.OnScoreChange -= OnScoreChange;
            gameObject.SetActive(false);
        }

        public IHide Show(IPlayerStatistic statistic)
        {
            PlayerStatistic = statistic;
            PlayerStatistic.OnScoreChange += OnScoreChange;
            return this;
        }

        // events
        private void OnScoreChange(Score score) => Label.text = score.ToString();
    }
}
