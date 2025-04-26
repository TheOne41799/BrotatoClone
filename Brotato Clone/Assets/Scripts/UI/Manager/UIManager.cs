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
            
        }

        private void CreateControllers()
        {
            uiHudController = new UIHUDController(uiData, uiCanvas);
        }

        private void DisposeControllers()
        {

        }

        private void OnHealthUpdated(int health) => uiHudController.OnUpdateHealth(health);



        // code for hiding and showing UI based on gamestate
    }
}