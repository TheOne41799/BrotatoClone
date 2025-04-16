using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private IPlayerInputController playerInputController;

        private IPlayerView playerView;

        public PlayerController(PlayerView playerViewPrefab) 
        {
            playerInputController = new PlayerInputController();
            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }

        public void Update()
        {
            playerView.TestMove(playerInputController.GetMovementVector());         
        }
    }
}