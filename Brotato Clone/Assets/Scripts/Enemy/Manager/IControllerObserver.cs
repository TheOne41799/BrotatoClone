using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IControllerObserver
    {
        void HandleApplyDamage(float damage);
    }
}