using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.UI
{
    public class UIMenuController
    {
        private UIManager uiManager;
        private UIMenu uiMenu;

        public UIMenuController(UIData uiData, Canvas uiCanvas, UIManager uiManager)
        {
            uiMenu = GameObject.Instantiate<UIMenu>(uiData.UIMenuPrefab, uiCanvas.transform);
            uiMenu.SetController(this);
            this.uiManager = uiManager;
        }

        public void ShowUI() => uiMenu.ShowUI();
        public void HideUI() => uiMenu.HideUI();
        public void HandleStartGame() => uiManager.HandleStartGame();
    }
}