using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using BrotatoClone.Event;
using BrotatoClone.Game;
using BrotatoClone.Input;
using BrotatoClone.Player;
using BrotatoClone.Tween;
using BrotatoClone.UI;
using BrotatoClone.VFX;
using BrotatoClone.Wave;
using BrotatoClone.Weapon;
using BrotatoClone.WorldItem;
using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        [SerializeField] private GameData gameData;

        private IEventManager eventManager;

        private IManager gameManager;
        private IManager inputManager;
        private IManager cameraManager;
        private IManager tweenManager;
        private IManager uiManager;
        private IManager enemyManager;
        private IManager weaponManager;
        private IManager playerManager;
        private IManager vfxManager;
        private IManager worldItemManager;
        private IManager waveManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {           
            CreateEventManager();
            CreateManagers();
            SetManagerDependencies();
        }

        private void CreateEventManager()
        {
            eventManager = new EventManager();
        }

        private void CreateManagers()
        {
            gameManager = GameObject.Instantiate<GameManager>(gameData.GameManagerPrefab, this.transform);
            inputManager = GameObject.Instantiate<InputManager>(gameData.InputManagerPrefab, this.transform);
            cameraManager = GameObject.Instantiate<CameraManager>(gameData.CameraManagerPrefab, this.transform);
            tweenManager = GameObject.Instantiate<TweenManager>(gameData.TweenManagerPrefab, this.transform);
            uiManager = GameObject.Instantiate<UIManager>(gameData.UIManagerPrefab, this.transform);
            enemyManager = GameObject.Instantiate<EnemyManager>(gameData.EnemyManagerPrefab, this.transform);
            weaponManager = GameObject.Instantiate<WeaponManager>(gameData.WeaponManagerPrefab, this.transform);
            playerManager = GameObject.Instantiate<PlayerManager>(gameData.PlayerManagerPrefab, this.transform);
            vfxManager = GameObject.Instantiate<VFXManager>(gameData.VFXManagerPrefab, this.transform);
            worldItemManager = GameObject.Instantiate<WorldItemManager>(gameData.WorldItemManagerPrefab, this.transform);
            waveManager = GameObject.Instantiate<WaveManager>(gameData.WaveManagerPrefab, this.transform);
        }

        private void SetManagerDependencies()
        {
            gameManager.InitializeManager(eventManager);
            inputManager.InitializeManager(eventManager);
            cameraManager.InitializeManager(eventManager);
            tweenManager.InitializeManager(eventManager);
            uiManager.InitializeManager(eventManager);
            enemyManager.InitializeManager(eventManager);
            weaponManager.InitializeManager(eventManager);
            playerManager.InitializeManager(eventManager);
            vfxManager.InitializeManager(eventManager);
            worldItemManager.InitializeManager(eventManager);
            waveManager.InitializeManager(eventManager);
        }
    }
}