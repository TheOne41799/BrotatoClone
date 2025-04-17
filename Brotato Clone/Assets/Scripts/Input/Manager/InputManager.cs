using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    public class InputManager : MonoBehaviour, IManager, IControllerOberver
    {
        private GameInputActionsAsset gameInputActionsAsset;

        private IEventManager eventManager;

        private IInputController playerInputController;

        private void Awake()
        {
            gameInputActionsAsset = new GameInputActionsAsset();
            playerInputController = new PlayerInputController((IControllerOberver) this, gameInputActionsAsset);



            //test
            gameInputActionsAsset.Player.Enable();
        }

        public void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager; 
        }

        public void OnPlayerMove(Vector2 moveInput)
        {
            Debug.Log(moveInput);
        }
    }
}