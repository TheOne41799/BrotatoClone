using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        private int moveSpeed = 5;

        private Vector2 velocity;

        public PlayerController(PlayerView playerViewPrefab) 
        {
            playerModel = new PlayerModel(moveSpeed);
            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }

        public void HandleMoveInput(Vector2 input)
        {
            Vector2 velocity = playerModel.CalculateVelocity(input);
            playerView.Move(velocity);
        }
    }
}