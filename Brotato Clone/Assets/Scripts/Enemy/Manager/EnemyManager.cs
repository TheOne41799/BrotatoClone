using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyManager : MonoBehaviour, IManager
    {
        [SerializeField] private EnemyData enemyData;

        private IEventManager eventManager;
        private ITarget target;

        private IEnemyController enemyController;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.PlayerEvents.OnTargetCreated.AddListener(ReceiveTargetTransform);

            // create an event to indicate player has been destroyed or use the same event
        }

        private void ReceiveTargetTransform(ITarget target)
        {
            this.target = target;


            //test

            CreateController();
        }

        private void CreateController()
        {
            enemyController = new EnemyController(enemyData.EnemyViewPrefab);
            enemyController.SetEnemyTarget(target);
        }

        private void DisposeController()
        {

        }

        private void Update()
        {
            if (enemyController != null)
            {
                enemyController.HandleFollowTarget();
            }
        }
    }
}