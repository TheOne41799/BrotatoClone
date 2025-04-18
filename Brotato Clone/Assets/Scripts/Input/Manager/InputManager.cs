using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    // Looks like there is an issue with IInputControllerObserver
    // Every time you create a new controller separate interface must be created in this setup
    // like UIInputControllerObserver
    // Also change the Player Action Map to Gameplay Action Map as the name makes more sense
    public class InputManager : MonoBehaviour, IManager, IInputControllerOberver
    {
        private GameInputActionsAsset gameInputActionsAsset;

        private IEventManager eventManager;

        private IInputController playerInputController;

        private void Awake()
        {
            gameInputActionsAsset = new GameInputActionsAsset();
            playerInputController = new PlayerInputController((IInputControllerOberver) this, gameInputActionsAsset);



            //test
            playerInputController.Enable();
        }

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {

        }

        public void HandleMoveInput(Vector2 moveInput)
        {       
            eventManager.InputEvents.OnMoveInput.Invoke(moveInput);
        }




        /*// Use the below method to update the current active action map
        private void UpdateInputActionMapStatus(var enums)
        {
            DisableAllActionMaps();

            switch statement to determine which action map should be currently active
        }*/



        /*// Use the below method to disable all the action maps first
        private void DisableAllActionMaps()
        {
            playerInputController.Disable();
        }*/
    }
}