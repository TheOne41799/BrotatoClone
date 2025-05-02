using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerControllerObserver
    {
        void ReportTargetTransform(ITarget target);
        void HandleHealthUpdate(HealthDisplayData healthDisplayData);
        void HandleXPUpdate(XPDisplayData xpDisplayData);
        void HandleRequestWeapon();
    }
}