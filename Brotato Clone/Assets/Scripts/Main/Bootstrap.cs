using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        [SerializeField] private GameData gameData;

        private IEventManager eventManager;

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
            playerManager = GameObject.Instantiate<PlayerManager>(gameData.PlayerManagerPrefab, this.transform);
        }

        private void SetManagerDependencies()
        {
            playerManager.SetManagerDependencies(eventManager);
        }
    }
}