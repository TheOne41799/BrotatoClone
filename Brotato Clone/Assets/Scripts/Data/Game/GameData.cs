using BrotatoClone.Input;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private PlayerManager playerManagerPrefab;
        [SerializeField] private InputManager inputManagerPrefab;

        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
        public InputManager InputManagerPrefab => inputManagerPrefab;
    }
}