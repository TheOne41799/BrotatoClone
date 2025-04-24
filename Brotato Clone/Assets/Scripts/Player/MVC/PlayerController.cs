using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private IPlayerControllerObserver playerManager;

        private IPlayerModel playerModel;
        private IPlayerView playerView;

        private float moveSpeed = 5;

        public PlayerController(IPlayerControllerObserver playerManager, PlayerView playerViewPrefab) 
        {
            this.playerManager = playerManager;

            playerModel = new PlayerModel(moveSpeed);

            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
            ReportTargetTransform((ITarget)playerView);
        }

        public void HandleMoveInput(Vector2 moveInput)
        {
            Vector2 velocity = playerModel.CalculateVelocity(moveInput);
            playerView.Move(velocity);
        }

        private void ReportTargetTransform(ITarget target)
        {
            playerManager.ReportTargetTransform(target);
        }
    }
}