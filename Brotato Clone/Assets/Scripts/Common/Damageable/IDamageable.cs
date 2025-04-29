using UnityEngine;

namespace BrotatoClone.Common
{
    public interface IDamageable
    {
        Vector2 GetPosition();
        void TakeDamage(float damage);
    }
}