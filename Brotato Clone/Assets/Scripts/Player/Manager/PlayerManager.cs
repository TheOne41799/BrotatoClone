using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Game;
using BrotatoClone.UI;
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
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager?.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
            eventManager?.InputEvents.OnMoveInput.AddListener(HandleMoveInput);
            eventManager?.EnemyEvents.OnApplyDamage.AddListener(HandleTakeDamage);
            eventManager?.WeaponEvents.OnWeaponCreated.AddListener(HandleReceiveWeapon);
            eventManager?.WorldItemEvents.OnItemCollected.AddListener(HandleItemCollected);
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.IN_GAME:
                    CreateController();
                    break;
            }
        }

        private void CreateController()
        {
            if (playerController != null) return;
            playerController = new PlayerController((IPlayerControllerObserver) this, playerData);
            playerController.HandleRequestWeapon();
        }

        private void DisposeController()
        {

        }

        private void HandleMoveInput(Vector2 moveInput)
        {
            playerController?.HandleMoveInput(moveInput);
        }

        public void ReportTargetTransform(ITarget target)
        {
            eventManager?.PlayerEvents.OnTargetUpdated.Invoke(target);
        }

        public void HandleTakeDamage(float damage)
        {
            playerController?.HandleTakeDamage(damage);
        }

        public void HandleHealthUpdate(HealthDisplayData healthDisplayData)
        {
            eventManager.PlayerEvents.OnHealthUpdated.Invoke(healthDisplayData);
        }

        public void HandleXPUpdate(XPDisplayData xpDisplayData)
        {
            eventManager.PlayerEvents.OnXPUpdated.Invoke(xpDisplayData);
        }

        public void HandleItemCollected(WorldItemCollected worldItemCollected)
        {
            playerController.HandleItemCollected(worldItemCollected);
        }

        public void HandleRequestWeapon()
        {
            eventManager.PlayerEvents.OnWeaponRequested?.Invoke(WeaponType.TEST);
        }

        public void HandleReceiveWeapon(WeaponSpawnData weaponSpawnData)
        {
            playerController.HandleReceiveWeapon(weaponSpawnData);
        }
    }
}