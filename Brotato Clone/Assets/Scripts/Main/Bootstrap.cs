using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using BrotatoClone.Event;
using BrotatoClone.Input;
using BrotatoClone.Player;
using BrotatoClone.Tween;
using BrotatoClone.UI;
using BrotatoClone.VFX;
using BrotatoClone.Weapon;
using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        [SerializeField] private GameData gameData;

        private IEventManager eventManager;

        private IManager inputManager;
        private IManager cameraManager;
        private IManager tweenManager;
        private IManager uiManager;
        private IManager enemyManager;
        private IManager playerManager;
        private IManager weaponManager;
        private IManager vfxManager;

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
            Application.targetFrameRate = 60;

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
            inputManager = GameObject.Instantiate<InputManager>(gameData.InputManagerPrefab, this.transform);
            cameraManager = GameObject.Instantiate<CameraManager>(gameData.CameraManagerPrefab, this.transform);
            tweenManager = GameObject.Instantiate<TweenManager>(gameData.TweenManagerPrefab, this.transform);
            uiManager = GameObject.Instantiate<UIManager>(gameData.UIManagerPrefab, this.transform);
            enemyManager = GameObject.Instantiate<EnemyManager>(gameData.EnemyManagerPrefab, this.transform);
            playerManager = GameObject.Instantiate<PlayerManager>(gameData.PlayerManagerPrefab, this.transform);
            weaponManager = GameObject.Instantiate<WeaponManager>(gameData.WeaponManagerPrefab, this.transform);
            vfxManager = GameObject.Instantiate<VFXManager>(gameData.VFXManagerPrefab, this.transform);
        }

        private void SetManagerDependencies()
        {
            inputManager.InitializeManager(eventManager);
            cameraManager.InitializeManager(eventManager);
            tweenManager.InitializeManager(eventManager);
            uiManager.InitializeManager(eventManager);
            enemyManager.InitializeManager(eventManager);
            playerManager.InitializeManager(eventManager);
            weaponManager.InitializeManager(eventManager);
            vfxManager.InitializeManager(eventManager);
        }
    }
}