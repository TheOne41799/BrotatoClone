using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private IPlayerControllerObserver playerManager;

        private IPlayerModel playerModel;
        private IPlayerView playerView;

        public PlayerController(IPlayerControllerObserver playerManager, PlayerData playerData) 
        {
            this.playerManager = playerManager;

            playerModel = new PlayerModel(playerData.MoveSpeed);

            playerView = GameObject.Instantiate<PlayerView>(playerData.PlayerViewPrefab);
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