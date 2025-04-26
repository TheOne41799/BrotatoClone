using UnityEngine;

namespace BrotatoClone.UI
{
    public class UIHUD : MonoBehaviour, IUIHUD
    {
        private void Awake() => ShowUI();
        
        public void ShowUI() => this.gameObject.SetActive(true);
        public void HideUI() => this .gameObject.SetActive(false);
        public void UpdateHealth(int health) { } /*uiHUD.UpdateHealth(health)*/
    }
}