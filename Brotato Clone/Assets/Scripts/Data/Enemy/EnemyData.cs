using BrotatoClone.Enemy;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Enemy Data", fileName = "Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private EnemyView enemyViewPrefab;
        [SerializeField] private float moveSpeed;
        [SerializeField, Range(0.5f, 1.5f)] private float attackRange;

        public EnemyView EnemyViewPrefab => enemyViewPrefab;
        public float MoveSpeed => moveSpeed;
        public float AttackRange => attackRange;
    }
}