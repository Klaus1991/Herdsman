using System;
using UnityEngine;
using UnityEngine.UI;

namespace Herdsman.Logic.UI
{
    public class MenuWindow : MonoBehaviour, IMenuSelector
    {
        [SerializeField]
        private Button StartButton;

        public event Action OnStartGame;

        private void Start() => StartButton.onClick.AddListener(OnButtonClick);

        private void OnDestroy() => StartButton.onClick.RemoveListener(OnButtonClick);

        public void Hide() => gameObject.SetActive(false);

        public IMenuSelector Show() => this;

        // events
        private void OnButtonClick() => OnStartGame?.Invoke();
    }
}
