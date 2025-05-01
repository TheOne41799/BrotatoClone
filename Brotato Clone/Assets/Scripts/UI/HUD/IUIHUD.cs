using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.UI
{
    public interface IUIHUD
    {
        void ShowUI();
        void HideUI();
        void UpdateHealth(HealthDisplayData healthDisplayData);
        void UpdateXP(XPDisplayData xpDisplayData);
    }
}