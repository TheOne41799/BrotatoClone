using BrotatoClone.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoClone.UI
{
    public class UIHUD : MonoBehaviour, IUIHUD
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthText;

        private void Awake() => ShowUI();
        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this.gameObject.SetActive(false);

        public void UpdateHealth(HealthDisplayData healthDisplayData)
        {
            healthText.text = healthDisplayData.currentHealth.ToString() + " / " + healthDisplayData.maxHealth.ToString();
            healthSlider.value = healthDisplayData.healthBarRatio;
        }
    }
}