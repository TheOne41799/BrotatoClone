using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemController
    {
        private WorldItemData worldItemData;
        private WorldItemManager worldItemManager;
        private CurrencyOneItemPool currencyOneItemPool;

        private CurrencyOneItemModel currencyOneItemModel;
        private CurrencyOneItemView currencyOneItemView;

        public bool IsCollected => currencyOneItemModel.IsCollected;

        public CurrencyOneItemController(WorldItemData worldItemData, WorldItemManager worldItemManager, CurrencyOneItemPool currencyOneItemPool)
        {
            this.worldItemData = worldItemData;
            this.worldItemManager = worldItemManager;
            this.currencyOneItemPool = currencyOneItemPool;
        }

        public void CreateItem()
        {
            currencyOneItemModel = new CurrencyOneItemModel(worldItemData);
            currencyOneItemModel.SetController(this);
            currencyOneItemView = GameObject.Instantiate<CurrencyOneItemView>(worldItemData.CurrencyOneItemViewPrefab, worldItemManager.transform);
            currencyOneItemView.SetController(this);
            currencyOneItemView.ToggleVisibility(true);
            currencyOneItemView.PlayAnimation();
        }

        public void GetFromPool()
        {
            currencyOneItemModel.InitModel();
            currencyOneItemView.ToggleVisibility(true);
            currencyOneItemView.PlayAnimation();
        }

        public void ReturnToPool()
        {
            currencyOneItemModel.ResetModel();
            currencyOneItemView.ToggleVisibility(false);
            currencyOneItemView.StopAnimation();
        }

        public void DestroyFromPool()
        {
            currencyOneItemModel.ResetModel();
            currencyOneItemModel = null;

            if (currencyOneItemView != null)
            {
                GameObject.Destroy(currencyOneItemView.gameObject);
                currencyOneItemView = null;
            }
        }

        public void SetSpawnPosition(Vector2 spawnPosition)
        {
            currencyOneItemView.SetSpawnPosition(spawnPosition);
        }

        public void HandleItemCollected(Transform targetTransform, Transform itemTransform)
        {
            worldItemManager.StartCoroutine(currencyOneItemModel.PlayItemCollectedAnimation(targetTransform, itemTransform));
        }

        public void HandleItemCollected()
        {
            currencyOneItemPool.HandleItemCollected(this, currencyOneItemModel.Quantity);
        }
    }
}