using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemModel
    {
        private WorldItemData worldItemData;
        public int Quantity { get; private set; }

        public CurrencyOneItemModel(WorldItemData worldItemData) 
        {
            this.worldItemData = worldItemData;

            SetQuantity();
        }

        public void SetQuantity()
        {
            Vector2 minMaxQuantity = worldItemData.CurrencyOneItemData.MinMaxQuantity;
            Quantity = Random.Range(Mathf.RoundToInt(minMaxQuantity.x), Mathf.RoundToInt(minMaxQuantity.y + 1));
        }

        public void ResetQuantity()
        {
            Quantity = 0;
        }
    }
}