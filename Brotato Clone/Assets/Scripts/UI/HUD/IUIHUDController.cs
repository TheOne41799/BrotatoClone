using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.UI
{
    public interface IUIHUDController
    {
        void ShowUI();
        void HideUI();
        void OnUpdateHealth(HealthDisplayData healthDisplayData);
        void OnUpdateXP(XPDisplayData xpDisplayData);
    }
}