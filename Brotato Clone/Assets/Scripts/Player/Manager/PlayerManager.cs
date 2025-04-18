using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerManager : MonoBehaviour, IManager, IPlayerControllerObserver
    {
        [SerializeField] private PlayerData playerData;

        private IEventManager eventManager;

        private IPlayerController playerController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();


            //test
            CreateController();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.InputEvents.OnMoveInput.AddListener(HandleMoveInput);
        }

        private void CreateController()
        {
            playerController = new PlayerController((IPlayerControllerObserver) this, playerData.PlayerViewPrefab);
        }

        private void DisposeController()
        {

        }

        private void HandleMoveInput(Vector2 moveInput)
        {
            playerController.HandleMoveInput(moveInput);
        }

        public void ReportCameraTarget(ITarget target)
        {
            eventManager.PlayerEvents.OnCameraTargetCreated.Invoke(target);
        }
    }
}