using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
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
            eventManager.PlayerEvents.OnHealthUpdated.AddListener(OnHealthUpdated);
            eventManager.PlayerEvents.OnXPUpdated.AddListener(OnXPUpdated);
        }

        private void CreateControllers()
        {
            uiHudController = new UIHUDController(uiData, uiCanvas);
        }

        private void DisposeControllers()
        {

        }

        private void OnHealthUpdated(HealthDisplayData healthDisplayData) => uiHudController.OnUpdateHealth(healthDisplayData);
        private void OnXPUpdated(XPDisplayData xpDisplayData) => uiHudController.OnUpdateXP(xpDisplayData);


        // code for hiding and showing UI based on gamestate
    }
}