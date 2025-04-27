using UnityEngine;

namespace BrotatoClone.Common
{
    public struct HealthDisplayData
    {
        public float currentHealth;
        public float maxHealth;
        public float healthBarRatio;
        
        public HealthDisplayData(float currentHealth, float maxHealth, float healthBarRatio)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
            this.healthBarRatio = healthBarRatio;
        }
    }
}