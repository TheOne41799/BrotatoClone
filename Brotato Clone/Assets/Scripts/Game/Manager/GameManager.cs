using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Game
{
    public class GameManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;
        private GameState currentGameState;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            SetGameState(GameState.MENU);
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

        private void SetGameState(GameState gameState)
        {
            if(currentGameState == gameState) return;

            currentGameState = gameState;

            //fire an event after updating the game state
        }
    }
}