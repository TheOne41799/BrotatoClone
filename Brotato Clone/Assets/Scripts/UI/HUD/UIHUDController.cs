using BrotatoClone.Data;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace BrotatoClone.UI
{
    public class UIHUDController : IUIHUDController
    {
        private IUIHUD uiHUD;

        public UIHUDController(UIData uiData, Canvas uiCanvas)
        {
            uiHUD = GameObject.Instantiate<UIHUD>(uiData.UIHUDPrefab, uiCanvas.transform);
        }

        public void ShowUI() => uiHUD.ShowUI();
        public void HideUI() => uiHUD.HideUI();
        public void OnUpdateHealth(int health) => uiHUD.UpdateHealth(health);

    }
}