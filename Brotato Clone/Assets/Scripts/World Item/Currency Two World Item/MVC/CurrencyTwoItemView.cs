using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyTwoItemView : MonoBehaviour, ICollectible
    {
        [SerializeField] private Animator currencyTwoAnimator;

        private CurrencyTwoItemController controller;

        public void SetController(CurrencyTwoItemController controller)
        {
            this.controller = controller;
        }

        public void PlayAnimation()
        {
            currencyTwoAnimator.Play("Idle");
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

        public void HandleItemCollected(Transform targetTransform)
        {
            if (controller.IsCollected) return;
            controller.HandleItemCollected(targetTransform, this.transform);
        }
    }
}