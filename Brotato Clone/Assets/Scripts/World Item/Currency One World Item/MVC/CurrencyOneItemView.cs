using BrotatoClone.Data;
using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemView : MonoBehaviour, ICollectible
    {
        [SerializeField] private Animator currencyOneAnimator;

        private CurrencyOneItemController controller;

        public void SetController(CurrencyOneItemController controller)
        {
            this.controller = controller;
        }

        public void PlayAnimation()
        {
            currencyOneAnimator.Play("Idle");
        }

        public void StopAnimation()
        {
            // stop animation
        }

        public void ToggleVisibility(bool visibility)
        {
            this.gameObject.SetActive(visibility);
        }

        public void SetSpawnPosition(Vector2 spawnPosition)
        {
            this.transform.position = spawnPosition;
        }

        public void OnItemCollected(Transform targetTransform)
        {
            if (controller.IsCollected) return;
            controller.OnCurrencyCollected(targetTransform, this.transform);
        }
    }
}