using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController, IPlayerViewObserver
    {
        private IPlayerControllerObserver playerManager;

        private IPlayerModel playerModel;
        private IPlayerView playerView;

        private int moveSpeed = 5;

        public PlayerController(IPlayerControllerObserver playerManager, PlayerView playerViewPrefab) 
        {
            this.playerManager = playerManager;

            playerModel = new PlayerModel(moveSpeed);
            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
            playerView.SetDependencies((IPlayerViewObserver) this);
        }

        public void HandleMoveInput(Vector2 moveInput)
        {
            Vector2 velocity = playerModel.CalculateVelocity(moveInput);
            playerView.Move(velocity);
        }

        public void HandlePlayerStatus(Vector3 position)
        {
            playerManager.HandlePlayerStatus(position);
        }
    }
}