using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IModelObserver
    {        
        void HandleApplyDamage(float damage);
    }
}