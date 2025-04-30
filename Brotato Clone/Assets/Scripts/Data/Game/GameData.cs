using BrotatoClone.Camera;
using BrotatoClone.Enemy;
using BrotatoClone.Input;
using BrotatoClone.Player;
using BrotatoClone.Tween;
using BrotatoClone.UI;
using BrotatoClone.VFX;
using BrotatoClone.Weapon;
using BrotatoClone.WorldItem;
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
        [SerializeField] private WeaponManager weaponManagerPrefab;
        [SerializeField] private VFXManager vfxManagerPrefab;
        [SerializeField] private WorldItemManager worldItemManagerPrefab;

        public InputManager InputManagerPrefab => inputManagerPrefab;
        public CameraManager CameraManagerPrefab => cameraManagerPrefab;
        public TweenManager TweenManagerPrefab => tweenManagerPrefab;
        public UIManager UIManagerPrefab => uiManagerPrefab;
        public PlayerManager PlayerManagerPrefab => playerManagerPrefab;
        public EnemyManager EnemyManagerPrefab => enemyManagerPrefab;
        public WeaponManager WeaponManagerPrefab => weaponManagerPrefab;
        public VFXManager VFXManagerPrefab => vfxManagerPrefab;
        public WorldItemManager WorldItemManagerPrefab => worldItemManagerPrefab;
    }
}