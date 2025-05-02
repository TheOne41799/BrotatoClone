using UnityEngine;

namespace BrotatoClone.Game
{
    public enum GameState
    {
        NONE,
        MENU,
        CHARACTER_WEAPON_SELECTION,
        IN_GAME,
        PAUSE,
        GAME_OVER,
        WAVE_TRANSITION,
        WAVE_COMPLETED,
        SHOP
    }
}