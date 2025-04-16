using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        private IDependencyContainer managerDependencies;

        private IEventManager eventManager;

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
            InitializeManagerDependencies();
            RegisterManagerDependencies();
            CreateManagers();
            SetManagerDependencies();
        }

        private void CreateEventManager()
        {
            eventManager = new EventManager();
        }

        private void InitializeManagerDependencies()
        {
            managerDependencies = new DependencyContainer();
        }

        private void RegisterManagerDependencies()
        {
            managerDependencies.Register<IEventManager>(eventManager);
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