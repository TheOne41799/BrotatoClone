using BrotatoClone.Enemy;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Enemy Data", fileName = "Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField] private EnemyView enemyViewPrefab;

        [Header("Movement")]
        [SerializeField] private float moveSpeed;

        [Header("Attack")]
        [SerializeField, Range(0.5f, 1.5f)] private float attackRange;
        [SerializeField] private int attackDamage;
        [SerializeField] private float attackRate;

        public EnemyView EnemyViewPrefab => enemyViewPrefab;
        public float MoveSpeed => moveSpeed;
        public float AttackRange => attackRange;
        public int AttackDamage => attackDamage;
        public float AttackRate => attackRate;
    }
}