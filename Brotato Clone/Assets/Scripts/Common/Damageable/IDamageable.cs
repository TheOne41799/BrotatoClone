using UnityEngine;

namespace BrotatoClone.Common
{
    public interface IDamageable
    {
        Vector2 GetPosition();
        Vector2 GetDamageTextSpawnPosition();
        void TakeDamage(float damage);
    }
}