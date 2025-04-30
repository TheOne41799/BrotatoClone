using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class WorldItemManager : MonoBehaviour, IManager
    {
        [SerializeField] private WorldItemData worldItemData;

        private IEventManager eventManager;

        private CurrencyOneItemPool currencyOneItemPool;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            CreateItemPools();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.EnemyEvents.OnEnemyDeath.AddListener(OnEnemyDeath);
        }

        private void CreateItemPools()
        {
            currencyOneItemPool = new CurrencyOneItemPool(this, worldItemData);
        }

        private void DisposeControllers()
        {

        }

        public void OnEnemyDeath(Vector2 spawnPosition)
        {
            currencyOneItemPool.OnEnemyDeath(spawnPosition);
        }
    }
}
