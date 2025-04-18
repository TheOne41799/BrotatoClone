using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Input;
using BrotatoClone.Player;
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
        private IManager playerManager;

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
            inputManager = GameObject.Instantiate<InputManager>(gameData.InputManagerPrefab, this.transform);
            cameraManager = GameObject.Instantiate<CameraManager>(gameData.CameraManagerPrefab, this.transform);
            playerManager = GameObject.Instantiate<PlayerManager>(gameData.PlayerManagerPrefab, this.transform);
        }

        private void SetManagerDependencies()
        {
            inputManager.InitializeManager(eventManager);
            cameraManager.InitializeManager(eventManager);
            playerManager.InitializeManager(eventManager);
        }
    }
}