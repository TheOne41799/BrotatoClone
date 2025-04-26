using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController, IPlayerModelObserver
    {
        private IPlayerControllerObserver playerManager;

        private IPlayerModel playerModel;
        private IPlayerView playerView;

        public PlayerController(IPlayerControllerObserver playerManager, PlayerData playerData) 
        {
            this.playerManager = playerManager;

            playerModel = new PlayerModel(playerData);
            playerModel.SetController(this);

            playerView = GameObject.Instantiate<PlayerView>(playerData.PlayerViewPrefab);
            ReportTargetTransform((ITarget)playerView);
        }        

        public void HandleMoveInput(Vector2 moveInput)
        {
            Vector2 velocity = playerModel.CalculateVelocity(moveInput);
            playerView.UpdateVelocity(velocity);
        }

        private void ReportTargetTransform(ITarget target)
        {
            playerManager.ReportTargetTransform(target);
        }

        public void HandleTakeDamage(float damage)
        {
            playerModel.TakeDamage(damage);
        }

        public void HandleHealthUpdate(float health)
        {
            playerManager.HandleHealthUpdate(health);
        }
    }
}