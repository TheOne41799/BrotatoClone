using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private IPlayerModel playerModel;
        private IPlayerView playerView;

        private int moveSpeed = 5;

        public PlayerController(PlayerView playerViewPrefab) 
        {
            playerModel = new PlayerModel(moveSpeed);
            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }

        public void HandleMoveInput(Vector2 moveInput)
        {
            Vector2 velocity = playerModel.CalculateVelocity(moveInput);
            playerView.Move(velocity);
        }
    }
}