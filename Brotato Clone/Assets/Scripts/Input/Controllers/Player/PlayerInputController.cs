using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    public class PlayerInputController: IInputController
    {
        private IControllerOberver inputManager;
        private GameInputActionsAsset gameInputActionsAsset;

        private Vector2 moveInput;

        public PlayerInputController(IControllerOberver inputManager, GameInputActionsAsset gameInpuActionsAsset)
        {
            this.inputManager = inputManager;
            this.gameInputActionsAsset = gameInpuActionsAsset;
        }

        public void Enable()
        {
            gameInputActionsAsset?.Player.Enable();
            this.gameInputActionsAsset.Player.Move.performed += OnMovePerformedCallback;
            this.gameInputActionsAsset.Player.Move.canceled += OnMoveCanceledCallback;
        }

        public void Disable()
        {
            gameInputActionsAsset?.Player.Disable();
            this.gameInputActionsAsset.Player.Move.performed -= OnMovePerformedCallback;
            this.gameInputActionsAsset.Player.Move.canceled -= OnMoveCanceledCallback;
        }

        private void OnMovePerformedCallback(InputAction.CallbackContext ctx)
        {
            moveInput = ctx.ReadValue<Vector2>();
            HandleMoveInput();
        }

        private void OnMoveCanceledCallback(InputAction.CallbackContext ctx)
        {
            moveInput = Vector2.zero;
            HandleMoveInput();
        }

        private void HandleMoveInput()
        {
            inputManager.HandleMoveInput(moveInput);
        }
    }
}