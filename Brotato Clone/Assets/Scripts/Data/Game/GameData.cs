using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private PlayerManager playerManagerPrefab;

        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
    }
}