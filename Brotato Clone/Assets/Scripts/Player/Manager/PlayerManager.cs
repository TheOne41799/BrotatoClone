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
            eventManager?.InputEvents.OnMoveInput.AddListener(HandleMoveInput);
            eventManager?.EnemyEvents.OnApplyDamage.AddListener(HandleTakeDamage);
            eventManager?.WorldItemEvents.OnItemCollected.AddListener(HandleItemCollected);
        }

        private void CreateController()
        {
            playerController = new PlayerController((IPlayerControllerObserver) this, playerData);
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

        public WeaponSpawnData OnWeaponRequested()
        {
            WeaponSpawnData weaponSpawnData = eventManager.PlayerEvents.OnWeaponRequested.Invoke<WeaponSpawnData>();
            return weaponSpawnData;
        }
    }
}