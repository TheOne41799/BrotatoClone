using UnityEngine;

namespace BrotatoClone.UI
{
    public interface IUIHUDController
    {
        void ShowUI();
        void HideUI();
        void OnUpdateHealth(int health);
    }
}