using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    public class PlayerInputController: IInputController
    {
        private GameInputActionsAsset gameInpuActionsAsset;

        public PlayerInputController(GameInputActionsAsset gameInpuActionsAsset)
        {
            this.gameInpuActionsAsset = gameInpuActionsAsset;
        }

        public void Enable()
        {
            gameInpuActionsAsset?.Player.Enable();
        }

        public void Disable()
        {
            gameInpuActionsAsset?.Player.Disable();
        }
    }
}