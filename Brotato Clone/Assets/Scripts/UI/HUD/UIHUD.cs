using BrotatoClone.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoClone.UI
{
    public class UIHUD : MonoBehaviour, IUIHUD
    {
        [Header("Health")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthText;

        [Header("Levelup")]
        [SerializeField] private Slider xpSlider;
        [SerializeField] private TextMeshProUGUI xpText;

        private void Awake() => HideUI();
        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this.gameObject.SetActive(false);

        public void UpdateHealth(HealthDisplayData healthDisplayData)
        {
            healthText.text = healthDisplayData.currentHealth.ToString() + " / " + healthDisplayData.maxHealth.ToString();
            healthSlider.value = healthDisplayData.healthBarRatio;
        }

        public void UpdateXP(XPDisplayData xpDisplayData)
        {
            xpText.text = "Level " + xpDisplayData.Level.ToString();
            xpSlider.value = xpDisplayData.XPBarRatio;
        }
    }
}