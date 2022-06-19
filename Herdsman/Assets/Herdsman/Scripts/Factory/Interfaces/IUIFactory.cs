
using Herdsman.Logic;
using Herdsman.Logic.UI;
using Infrastructure.Models;
using UnityEngine;

namespace Herdsman.Factory
{
    public interface IHudFactory
    {
        IMenuSelector ShowGameMenu();

        IHide ShowScoreUI(IPlayerStatistic statistic);
    }
}
