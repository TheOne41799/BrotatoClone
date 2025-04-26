using UnityEngine;

namespace BrotatoClone.UI
{
    public interface IUIHUD
    {
        void ShowUI();
        void HideUI();
        void UpdateHealth(float health);
    }
}