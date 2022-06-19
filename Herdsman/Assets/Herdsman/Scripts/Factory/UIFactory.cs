using Herdsman.Data.Scriptable;
using Herdsman.Logic;
using Herdsman.Logic.UI;
using Infrastructure.Data.Scriptable;
using Infrastructure.Factory;
using Infrastructure.Models;
using Infrastructure.UnityContext.UI;

namespace Herdsman.Factory
{
    public class UIFactory : BaseFactory, IHudFactory
    {
        private readonly UIData UIData;

        public UIFactory()
        {
            UIData = ScriptableData.Get<UIData>();
        }

        public IMenuSelector ShowGameMenu()
        {
            var uiPrefab = UIData.GameMenu;
            var uiObject = UIView.ShowWindow(uiPrefab);
            return uiObject.GetComponent<IMenuSelector>().Show();
        }

        public IHide ShowScoreUI(IPlayerStatistic statistic)
        {
            var uiPrefab = UIData.ScoreUI;
            var uiObject = UIView.ShowWindow(uiPrefab);
            return uiObject.GetComponent<IShowWithArgs<IHide, IPlayerStatistic>>().Show(statistic);
        }
    }
}
