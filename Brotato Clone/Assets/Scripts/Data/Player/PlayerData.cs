using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Player Data", fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private PlayerView playerViewPrefab;

        [Header("Player Properties")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxHealth;

        public PlayerView PlayerViewPrefab => playerViewPrefab;
        public float MoveSpeed => moveSpeed;
        public float MaxHealth => maxHealth;
    }
}
