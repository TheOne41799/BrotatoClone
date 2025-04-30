using BrotatoClone.Data;
using UnityEngine;
using UnityEngine.Pool;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemPool
    {
        private WorldItemManager worldItemManager;
        private WorldItemData worldItemData;

        private ObjectPool<CurrencyOneItemController> currencyOneItemPool;

        public CurrencyOneItemPool(WorldItemManager worldItemManager, WorldItemData worldItemData)
        {
            this.worldItemManager = worldItemManager;
            this.worldItemData = worldItemData;

            currencyOneItemPool = new ObjectPool<CurrencyOneItemController>(CreateItemController,
                                                                            OnGetItemController,
                                                                            OnReleaseItemController,
                                                                            OnDestroyItemController);
        }

        private CurrencyOneItemController CreateItemController()
        {
            CurrencyOneItemController currencyOneItemController = new CurrencyOneItemController(worldItemData, worldItemManager, this);
            currencyOneItemController.CreateItem();
            return currencyOneItemController;
        }

        private void OnGetItemController(CurrencyOneItemController currencyOneItemController)
        {
            currencyOneItemController.GetFromPool();
        }

        private void OnReleaseItemController(CurrencyOneItemController currencyOneItemController)
        {
            currencyOneItemController.ReturnToPool();
        }

        private void OnDestroyItemController(CurrencyOneItemController currencyOneItemController)
        {
            currencyOneItemController.DestroyFromPool();
        }

        public void OnEnemyDeath(Vector2 spawnPosition)
        {
            CurrencyOneItemController currencyOnePooledItem = currencyOneItemPool.Get();
            currencyOnePooledItem.SetSpawnPosition(spawnPosition);
        }

        public void OnCashCollected(CurrencyOneItemController controller)
        {
            currencyOneItemPool.Release(controller);
        }
    }
}