using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerModel: IPlayerModel
    {
        private IPlayerModelObserver playerController;
        public float MoveSpeed { get; private set; }

        private readonly float maxHealth;
        private float currentHealth;

        public PlayerModel(PlayerData playerData)
        {
            this.MoveSpeed = playerData.MoveSpeed;
            this.maxHealth = playerData.MaxHealth;
            this.currentHealth = playerData.MaxHealth;
        }

        public void SetController(IPlayerModelObserver playerController)
        {
            this.playerController = playerController;
        }

        public Vector2 CalculateVelocity(Vector2 inputDirection)
        {
            return inputDirection * MoveSpeed;
        }

        public void TakeDamage(float damage)
        {
            float adjustedDamage = Mathf.Min(damage, currentHealth);
            currentHealth -= adjustedDamage;
            float healthRatio = currentHealth / maxHealth;
            
            playerController.HandleHealthUpdate(healthRatio);

            if (currentHealth <= 0) Dispose();
        }

        public void Dispose()
        {
            Debug.Log("Player is disposed");
        }
    }
}