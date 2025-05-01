using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyTwoItemController
    {
        private WorldItemData worldItemData;
        private WorldItemManager worldItemManager;
        private CurrencyTwoItemPool currencyTwoItemPool;

        private CurrencyTwoItemModel currencyTwoItemModel;
        private CurrencyTwoItemView currencyTwoItemView;

        public bool IsCollected => currencyTwoItemModel.IsCollected;

        public CurrencyTwoItemController(WorldItemData worldItemData, WorldItemManager worldItemManager, CurrencyTwoItemPool currencyTwoItemPool)
        {
            this.worldItemData = worldItemData;
            this.worldItemManager = worldItemManager;
            this.currencyTwoItemPool = currencyTwoItemPool;
        }

        public void CreateItem()
        {
            currencyTwoItemModel = new CurrencyTwoItemModel(worldItemData);
            currencyTwoItemModel.SetController(this);
            currencyTwoItemView = GameObject.Instantiate<CurrencyTwoItemView>(worldItemData.CurrencyTwoItemViewPrefab, worldItemManager.transform);
            currencyTwoItemView.SetController(this);
            currencyTwoItemView.ToggleVisibility(true);
            currencyTwoItemView.PlayAnimation();
        }

        public void GetFromPool()
        {
            currencyTwoItemModel.InitModel();
            currencyTwoItemView.ToggleVisibility(true);
            currencyTwoItemView.PlayAnimation();
        }

        public void ReturnToPool()
        {
            currencyTwoItemModel.ResetModel();
            currencyTwoItemView.ToggleVisibility(false);
            currencyTwoItemView.StopAnimation();
        }

        public void DestroyFromPool()
        {
            currencyTwoItemModel.ResetModel();
            currencyTwoItemModel = null;

            if (currencyTwoItemView != null)
            {
                GameObject.Destroy(currencyTwoItemView.gameObject);
                currencyTwoItemView = null;
            }
        }

        public void SetSpawnPosition(Vector2 spawnPosition)
        {
            currencyTwoItemView.SetSpawnPosition(spawnPosition);
        }

        public void OnCurrencyCollected(Transform targetTransform, Transform itemTransform)
        {
            worldItemManager.StartCoroutine(currencyTwoItemModel.PlayItemCollectedAnimation(targetTransform, itemTransform));
        }

        public void OnCurrencyCollected()
        {
            currencyTwoItemPool.OnCurrencyCollected(this);
        }
    }
}