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
            playerModel.InitModel();

            playerView = GameObject.Instantiate<PlayerView>(playerData.PlayerViewPrefab);
            ReportTargetTransform((ITarget)playerView);
            playerView.AddWeapon(playerManager.OnWeaponRequested());
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

        public void HandleHealthUpdate(HealthDisplayData healthDisplayData)
        {
            playerManager.HandleHealthUpdate(healthDisplayData);
        }

        public void HandleItemCollected(WorldItemCollected worldItemCollected)
        {
            playerModel.HandleItemCollected(worldItemCollected);
        }

        public void HandleXPUpdate(XPDisplayData xpDisplayData)
        {
            playerManager.HandleXPUpdate(xpDisplayData);
        }
    }
}