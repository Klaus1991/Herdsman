
using System;
using Herdsman.Factory;

namespace Herdsman.Logic.UI
{
    public class GameMenu : IGameMenu
    {
        private readonly IHudFactory UIFactory;

        public event Action OnNextState;

        private IMenuSelector ActiveMenu;

        public GameMenu(IHudFactory uiFactory)
        {
            UIFactory = uiFactory;
        }

        public void Build()
        {
            ActiveMenu = UIFactory.ShowGameMenu();
            ActiveMenu.OnStartGame += OnStartClick;
        }

        public void Dispose()
        {
            ActiveMenu.OnStartGame -= OnStartClick;
            ActiveMenu.Hide();
        }

        // events
        private void OnStartClick()
        {
            OnNextState?.Invoke();
        }
    }
}
