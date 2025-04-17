using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    public class PlayerInputController: IInputController
    {
        private GameInputActionsAsset gameInputActionsAsset;

        public PlayerInputController(GameInputActionsAsset gameInpuActionsAsset)
        {
            this.gameInputActionsAsset = gameInpuActionsAsset;

            this.gameInputActionsAsset.Player.Move.performed += OnMovePerformedCallback;
            this.gameInputActionsAsset.Player.Move.canceled += OnMoveCanceledCallback;
        }

        public void Enable()
        {
            gameInputActionsAsset?.Player.Enable();
        }

        public void Disable()
        {
            gameInputActionsAsset?.Player.Disable();
        }

        private void OnMovePerformedCallback(InputAction.CallbackContext ctx)
        {
            Vector2 moveInput = ctx.ReadValue<Vector2>();
        }

        private void OnMoveCanceledCallback(InputAction.CallbackContext ctx)
        {
            
        }
    }
}