using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Player;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace BrotatoClone.Enemy
{
    public class EnemyManager : MonoBehaviour, IManager, IControllerObserver
    {
        [SerializeField] private EnemyData enemyData;

        private IEventManager eventManager;
        private ITarget target;

        private List<IEnemyController> enemyControllers = new List<IEnemyController>();

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
            eventManager.PlayerEvents.OnTargetUpdated.AddListener(ReceiveTargetTransform);

            // create an event to indicate player has been destroyed or use the same event
        }

        private void ReceiveTargetTransform(ITarget target)
        {
            this.target = target;


            //test

            /*CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();
            CreateController();*/
        }

        private void CreateController()
        {
            IEnemyController controller = new EnemyController(enemyData, this);
            controller.SetEnemyTarget(target);
            enemyControllers.Add(controller);
        }

        private void DisposeController()
        {

        }

        private void Update()
        {
            if (enemyControllers != null)
            {
                foreach (IEnemyController enemyController in enemyControllers)
                {
                    enemyController.HandleFollowTarget();
                    enemyController.HandleTryAttackTarget();
                }
            }
        }

        public void HandleApplyDamage(float damage)
        {            
            eventManager.EnemyEvents.OnApplyDamage.Invoke(damage);
        }

        public void OnEnemyDeath(Vector2 enemyDeathPosition)
        {
            eventManager.EnemyEvents.OnEnemyDeath.Invoke(enemyDeathPosition);
        }
    }
}