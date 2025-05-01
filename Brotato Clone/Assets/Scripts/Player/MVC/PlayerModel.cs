using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerModel: IPlayerModel
    {
        private IPlayerModelObserver playerController;
        private PlayerData playerData;
        public float MoveSpeed { get; private set; }

        private readonly float maxHealth;
        private float currentHealth;

        private int currentXP;
        private int requiredXP;
        private int level;

        public PlayerModel(PlayerData playerData)
        {
            this.playerData = playerData;

            this.MoveSpeed = playerData.MoveSpeed;
            this.maxHealth = playerData.MaxHealth;
            this.currentHealth = playerData.MaxHealth;
        }

        public void SetController(IPlayerModelObserver playerController)
        {
            this.playerController = playerController;
        }

        public void InitModel()
        {
            HealthDisplayData healthDisplayData = new HealthDisplayData(playerData.MaxHealth, playerData.MaxHealth, 1f);
            playerController.HandleHealthUpdate(healthDisplayData);

            UpdateRequiredXP();

            XPDisplayData xpDisplayData = new XPDisplayData(0f, level);
            playerController.HandleXPUpdate(xpDisplayData);
        }

        public Vector2 CalculateVelocity(Vector2 inputDirection)
        {
            return inputDirection * MoveSpeed;
        }

        public void TakeDamage(float damage)
        {
            float adjustedDamage = Mathf.Min(damage, currentHealth);
            currentHealth -= adjustedDamage;
            float healthBarRatio = currentHealth / maxHealth;

            HealthDisplayData healthDisplayData = new HealthDisplayData(currentHealth, maxHealth, healthBarRatio);
            playerController.HandleHealthUpdate(healthDisplayData);

            if (currentHealth <= 0) Dispose();
        }        

        public void HandleItemCollected(WorldItemCollected worldItemCollected)
        {
            switch (worldItemCollected.WorldItemType)
            {
                case WorldItemType.CURRENCY_ONE:
                    OnCurrencyOneCollected(worldItemCollected.Quantity);
                    break;
                case WorldItemType.CURRENCY_TWO:
                    //Debug.Log($"Currency Two collected + quantity {worldItemCollected.Quantity}");
                    break;
            }
        }

        private void OnCurrencyOneCollected(int quantity)
        {
            currentXP += quantity;            

            if (currentXP >= requiredXP)
            {
                int leftoverXP = currentXP - requiredXP;
                Levelup(leftoverXP);
            }

            float xpBarRatio = (float) currentXP / requiredXP;

            XPDisplayData xpDisplayData = new XPDisplayData(xpBarRatio, level);
            playerController.HandleXPUpdate(xpDisplayData);
        }

        private void Levelup(int leftoverXP)
        {
            level++;
            currentXP = leftoverXP;
            UpdateRequiredXP();
        }

        private void UpdateRequiredXP()
        {
            requiredXP = (level + 1) * 5;
        }

        public void Dispose()
        {
            Debug.Log("Player is disposed");
        }
    }
}