using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrotatoClone.Input
{
    public class InputManager : MonoBehaviour, IManager
    {
        private GameInputActionsAsset gameInputActionsAsset;

        private IEventManager eventManager;

        private IInputController playerInputController;

        private void Awake()
        {
            gameInputActionsAsset = new GameInputActionsAsset();
            playerInputController = new PlayerInputController(gameInputActionsAsset);
        }

        public void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager; 
        }
    }
}