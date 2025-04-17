using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        private int moveSpeed = 5;

        private Vector2 moveInput;

        public PlayerController(PlayerView playerViewPrefab) 
        {
            playerModel = new PlayerModel(moveSpeed);
            playerView = GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }

        public void SetMoveInput(Vector2 input)
        {
            moveInput = input;
        }

        public void Update()
        {
            playerView.Move(moveInput, playerModel.MoveSpeed);
        }
    }
}