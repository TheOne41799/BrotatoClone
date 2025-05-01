using BrotatoClone.Data;
using System.Collections;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemModel
    {
        private CurrencyOneItemController controller;
        private WorldItemData worldItemData;
        public int Quantity { get; private set; }
        public bool IsCollected { get; private set; }

        public CurrencyOneItemModel(WorldItemData worldItemData) 
        {
            this.worldItemData = worldItemData;

            InitModel();
        }

        public void SetController(CurrencyOneItemController controller)
        {
            this.controller = controller;
        }

        public void InitModel()
        {
            IsCollected = false;
            Vector2 minMaxQuantity = worldItemData.CurrencyOneItemData.MinMaxQuantity;
            Quantity = Random.Range(Mathf.RoundToInt(minMaxQuantity.x), Mathf.RoundToInt(minMaxQuantity.y + 1));
        }

        public void ResetModel()
        {
            IsCollected = false;
            Quantity = 0;
        }

        public IEnumerator PlayItemCollectedAnimation(Transform targetTransform, Transform itemTransform)
        {
            if (IsCollected) yield break;

            IsCollected = true;

            float timer = 0f;
            float duration = 1f;

            while (timer < duration)
            {
                itemTransform.position = Vector2.Lerp(itemTransform.position, targetTransform.position, timer / duration);

                if (Vector2.Distance(itemTransform.position, targetTransform.position) < 0.1f)
                {
                    break;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            itemTransform.position = targetTransform.position;

            controller.OnCashCollected();
        }
    }
}