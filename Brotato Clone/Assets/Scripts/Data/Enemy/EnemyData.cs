using BrotatoClone.Enemy;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Enemy Data", fileName = "Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private EnemyView enemyViewPrefab;

        public EnemyView EnemyViewPrefab => enemyViewPrefab;
    }
}