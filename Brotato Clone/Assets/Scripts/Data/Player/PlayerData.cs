using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Player Data", fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private PlayerView playerViewPrefab;
        [SerializeField] private float moveSpeed;

        public PlayerView PlayerViewPrefab => playerViewPrefab;
        public float MoveSpeed => moveSpeed;
    }
}
