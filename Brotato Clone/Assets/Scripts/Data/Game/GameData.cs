using BrotatoClone.Camera;
using BrotatoClone.Enemy;
using BrotatoClone.Input;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private InputManager inputManagerPrefab;
        [SerializeField] private CameraManager cameraManagerPrefab;
        [SerializeField] private PlayerManager playerManagerPrefab;
        [SerializeField] private EnemyManager enemyManagerPrefab;

        public InputManager InputManagerPrefab => inputManagerPrefab;
        public CameraManager CameraManagerPrefab => cameraManagerPrefab;
        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
        public EnemyManager EnemyManagerPrefab => enemyManagerPrefab;
    }
}