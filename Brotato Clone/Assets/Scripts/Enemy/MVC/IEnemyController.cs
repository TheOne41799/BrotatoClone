using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyController
    {
        void SetEnemyTarget(ITarget target);
        void HandleFollowTarget();
    }
}