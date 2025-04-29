using UnityEngine;

namespace BrotatoClone.Common
{
    public struct DamageDisplayData
    {
        public Vector2 spawnPosition;
        public float damageAmount;

        public DamageDisplayData(Vector2 spawnPosition, float damageAmount)
        {
            this.spawnPosition = spawnPosition;
            this.damageAmount = damageAmount;
        }
    }
}