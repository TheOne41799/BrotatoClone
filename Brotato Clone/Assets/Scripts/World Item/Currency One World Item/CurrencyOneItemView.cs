using BrotatoClone.Data;
using BrotatoClone.VFX;
using UnityEngine;

namespace BrotatoClone.WorldItem
{
    public class CurrencyOneItemView : MonoBehaviour
    {
        //[SerializeField] private Animator currencyOneAnimator;

        public void PlayAnimation()
        {
            // play animation
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
    }
}