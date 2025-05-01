using BrotatoClone.Data;
using UnityEngine;
using System.Collections;

namespace BrotatoClone.WorldItem
{
    public class CurrencyTwoItemModel
    {
        private CurrencyTwoItemController controller;
        private WorldItemData worldItemData;
        public int Quantity { get; private set; }
        public bool IsCollected { get; private set; }

        public CurrencyTwoItemModel(WorldItemData worldItemData)
        {
            this.worldItemData = worldItemData;

            InitModel();
        }

        public void SetController(CurrencyTwoItemController controller)
        {
            this.controller = controller;
        }

        public void InitModel()
        {
            IsCollected = false;
            Vector2 minMaxQuantity = worldItemData.CurrencyTwoItemData.MinMaxQuantity;
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

            yield return PopUpAnimation(itemTransform, 2.5f, 0.2f);
            yield return SpinAndScaleAnimation(itemTransform, 720f, 1.3f, 0.4f);
            yield return MoveTowardsTarget(itemTransform, targetTransform, 1f);

            controller.OnCurrencyCollected();
        }

        private IEnumerator PopUpAnimation(Transform itemTransform, float height, float duration)
        {
            Vector3 start = itemTransform.position;
            Vector3 end = start + Vector3.up * height;
            float timer = 0f;

            while (timer < duration)
            {
                itemTransform.position = Vector3.Lerp(start, end, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }

            itemTransform.position = end;
        }

        private IEnumerator SpinAndScaleAnimation(Transform itemTransform, float spinSpeed, float scaleAmount, float duration)
        {
            Vector3 originalScale = itemTransform.localScale;
            float timer = 0f;

            while (timer < duration)
            {
                itemTransform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);

                float t = Mathf.PingPong(timer * 4f, 1f);
                itemTransform.localScale = originalScale * Mathf.Lerp(1f, scaleAmount, t);

                timer += Time.deltaTime;
                yield return null;
            }

            itemTransform.localScale = originalScale;
            itemTransform.rotation = Quaternion.identity;
        }

        private IEnumerator MoveTowardsTarget(Transform itemTransform, Transform targetTransform, float duration)
        {
            float timer = 0f;

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
        }
    }
}
