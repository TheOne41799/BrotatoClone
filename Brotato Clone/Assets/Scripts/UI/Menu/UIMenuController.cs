using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.UI
{
    public class UIMenuController
    {
        private UIMenu uiMenu;

        public UIMenuController(UIData uiData, Canvas uiCanvas)
        {
            uiMenu = GameObject.Instantiate<UIMenu>(uiData.UIMenuPrefab, uiCanvas.transform);
        }

        public void ShowUI() => uiMenu.ShowUI();
        public void HideUI() => uiMenu.HideUI();
    }
}