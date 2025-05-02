using BrotatoClone.Game;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class GameEvents
    {
        public IEventController<Action<GameState>> OnGameStateUpdated {  get; private set; }
        public IEventController<Action> OnGameStart {  get; private set; }

        public GameEvents()
        {
            OnGameStateUpdated = new EventController<Action<GameState>>();
            OnGameStart = new EventController<Action>();
        }
    }
}