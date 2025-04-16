using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

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
            //Debug.Log("Create Managers");
            
        }

        private void SetManagerDependencies()
        {
            //Debug.Log("Set Manager Dependencies");
        }
    }
}