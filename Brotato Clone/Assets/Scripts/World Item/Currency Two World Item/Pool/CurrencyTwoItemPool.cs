using BrotatoClone.Data;
using UnityEngine;
using UnityEngine.Pool;

namespace BrotatoClone.WorldItem
{
    public class CurrencyTwoItemPool
    {
        private WorldItemManager worldItemManager;
        private WorldItemData worldItemData;

        private ObjectPool<CurrencyTwoItemController> currencyTwoItemPool;

        public CurrencyTwoItemPool(WorldItemManager worldItemManager, WorldItemData worldItemData)
        {
            this.worldItemManager = worldItemManager;
            this.worldItemData = worldItemData;

            currencyTwoItemPool = new ObjectPool<CurrencyTwoItemController>(CreateItemController,
                                                                            OnGetItemController,
                                                                            OnReleaseItemController,
                                                                            OnDestroyItemController);
        }

        private CurrencyTwoItemController CreateItemController()
        {
            CurrencyTwoItemController currencyTwoItemController = new CurrencyTwoItemController(worldItemData, worldItemManager, this);
            currencyTwoItemController.CreateItem();
            return currencyTwoItemController;
        }

        private void OnGetItemController(CurrencyTwoItemController currencyTwoItemController)
        {
            currencyTwoItemController.GetFromPool();
        }

        private void OnReleaseItemController(CurrencyTwoItemController currencyTwoItemController)
        {
            currencyTwoItemController.ReturnToPool();
        }

        private void OnDestroyItemController(CurrencyTwoItemController currencyTwoItemController)
        {
            currencyTwoItemController.DestroyFromPool();
        }

        public void OnEnemyDeath(Vector2 spawnPosition)
        {
            CurrencyTwoItemController currencyTwoPooledItem = currencyTwoItemPool.Get();
            currencyTwoPooledItem.SetSpawnPosition(spawnPosition);
        }

        public void OnCurrencyCollected(CurrencyTwoItemController controller)
        {
            currencyTwoItemPool.Release(controller);
        }
    }
}