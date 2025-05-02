using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Game;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.UI
{
    public class UIManager : MonoBehaviour, IManager
    {
        [SerializeField] private UIData uiData;
        [SerializeField] private Canvas uiCanvas;

        private IEventManager eventManager;

        private IUIHUDController uiHudController;
        private UIMenuController uiMenuController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            CreateControllers();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
            eventManager.PlayerEvents.OnHealthUpdated.AddListener(OnHealthUpdated);
            eventManager.PlayerEvents.OnXPUpdated.AddListener(OnXPUpdated);
        }

        private void CreateControllers()
        {
            uiHudController = new UIHUDController(uiData, uiCanvas);
            uiMenuController = new UIMenuController(uiData, uiCanvas, this);
        }

        private void DisposeControllers()
        {

        }

        private void OnGameStateUpdated(GameState gameState)
        {
            HideAllUIs();

            switch (gameState)
            {
                case GameState.MENU:
                    uiMenuController?.ShowUI();
                    break;
                case GameState.IN_GAME:
                    uiHudController?.ShowUI();
                    break;
                case GameState.PAUSE:
                    break;
            }
        }

        private void OnHealthUpdated(HealthDisplayData healthDisplayData) => uiHudController.OnUpdateHealth(healthDisplayData);
        private void OnXPUpdated(XPDisplayData xpDisplayData) => uiHudController.OnUpdateXP(xpDisplayData);
        public void HandleStartGame() => eventManager.GameEvents.OnGameStart.Invoke();

        private void HideAllUIs()
        {
            uiHudController.HideUI();
            uiMenuController.HideUI();
        }
    }
}