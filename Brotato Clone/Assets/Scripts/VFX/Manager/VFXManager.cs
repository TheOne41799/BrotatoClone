using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.VFX
{
    public class VFXManager : MonoBehaviour, IManager
    {
        [SerializeField] private VFXData vfxData;

        private IEventManager eventManager;

        private DamageTextController damageTextController;

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
            eventManager.WeaponEvents.OnEnemyHit.AddListener(HandleEnemyHit);
        }

        private void CreateControllers()
        {
            damageTextController = new DamageTextController(vfxData, this);
        }

        private void DisposeControllers()
        {
        }

        private void HandleEnemyHit(DamageDisplayData damageDisplayData)
        {
            damageTextController.HandleEnemyHit(damageDisplayData);
        }
    }
}