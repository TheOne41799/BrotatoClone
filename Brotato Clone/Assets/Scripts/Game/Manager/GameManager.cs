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
            currentGameState = GameState.MENU;
            UpdateTimeScale();
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
            eventManager.GameEvents.OnGameStart.AddListener(HandleGameStart);
        }

        private void SetGameState(GameState gameState)
        {
            if(currentGameState == gameState) return;

            currentGameState = gameState;
            UpdateTimeScale();

            eventManager.GameEvents.OnGameStateUpdated.Broadcast(currentGameState);
        }

        private void UpdateTimeScale()
        {
            Time.timeScale = currentGameState == GameState.IN_GAME ? 1f : 0f;
        }

        private void HandleGameStart() => SetGameState(GameState.IN_GAME);
    }
}