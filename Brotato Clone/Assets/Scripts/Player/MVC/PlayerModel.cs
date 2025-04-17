using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerModel: IPlayerModel
    {
        public float MoveSpeed { get; private set; }

        public PlayerModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}