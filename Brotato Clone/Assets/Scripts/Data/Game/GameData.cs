using BrotatoClone.Camera;
using BrotatoClone.Enemy;
using BrotatoClone.Input;
using BrotatoClone.Player;
using BrotatoClone.Tween;
using BrotatoClone.UI;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Game Data", fileName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private InputManager inputManagerPrefab;
        [SerializeField] private CameraManager cameraManagerPrefab;
        [SerializeField] private TweenManager tweenManagerPrefab;
        [SerializeField] private UIManager uiManagerPrefab;
        [SerializeField] private PlayerManager playerManagerPrefab;
        [SerializeField] private EnemyManager enemyManagerPrefab;

        public InputManager InputManagerPrefab => inputManagerPrefab;
        public CameraManager CameraManagerPrefab => cameraManagerPrefab;
        public TweenManager TweenManagerPrefab => tweenManagerPrefab;
        public UIManager UIManagerPrefab => uiManagerPrefab;
        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
        public EnemyManager EnemyManagerPrefab => enemyManagerPrefab;
    }
}