using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
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
            ReportCameraTarget((ITarget)playerView);
        }

        public void HandleMoveInput(Vector2 moveInput)
        {
            Vector2 velocity = playerModel.CalculateVelocity(moveInput);
            playerView.Move(velocity);
        }

        private void ReportCameraTarget(ITarget target)
        {
            playerManager.ReportCameraTarget(target);
        }
    }
}