using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemController
    {
        private WorldItemData worldItemData;

        private CurrencyOneItemModel currencyOneItemModel;
        private CurrencyOneItemView currencyOneItemView;

        public CurrencyOneItemController(WorldItemData worldItemData)
        {
            this.worldItemData = worldItemData;
        }

        public void CreateItem()
        {
            currencyOneItemModel = new CurrencyOneItemModel(worldItemData);
            currencyOneItemView = GameObject.Instantiate<CurrencyOneItemView>(worldItemData.CurrencyOneItemViewPrefab);
            currencyOneItemView.ToggleVisibility(true);
            currencyOneItemView.PlayAnimation();
        }

        public void GetFromPool()
        {
            currencyOneItemModel.SetQuantity();
            currencyOneItemView.ToggleVisibility(true);
            currencyOneItemView.PlayAnimation();
        }

        public void ReturnToPool()
        {
            currencyOneItemModel.ResetQuantity();
            currencyOneItemView.ToggleVisibility(false);
            currencyOneItemView.StopAnimation();
        }

        public void DestroyFromPool()
        {
            currencyOneItemModel.ResetQuantity();
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
    }
}