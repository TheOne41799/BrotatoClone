using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerModel: IPlayerModel
    {
        public float MoveSpeed { get; private set; }
        private int health;

        public PlayerModel(PlayerData playerData)
        {
            this.MoveSpeed = playerData.MoveSpeed;
            this.health = playerData.Health;
        }

        public Vector2 CalculateVelocity(Vector2 inputDirection)
        {
            return inputDirection * MoveSpeed;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}