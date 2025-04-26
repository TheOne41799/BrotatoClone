using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerModel: IPlayerModel
    {
        private IPlayerModelObserver playerController;
        public float MoveSpeed { get; private set; }
        private float health;

        public PlayerModel(PlayerData playerData)
        {
            this.MoveSpeed = playerData.MoveSpeed;
            this.health = playerData.Health;
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
            health -= damage;
            
            playerController.HandleHealthUpdate(health);
        }
    }
}