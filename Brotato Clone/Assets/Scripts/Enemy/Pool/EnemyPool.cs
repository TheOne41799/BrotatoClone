using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace BrotatoClone.Enemy
{
    public class EnemyPool
    {
        private EnemyManager enemyManager;
        private EnemyData enemyData;

        private ObjectPool<IEnemyController> enemyPool;
        private List<IEnemyController> enemyControllers = new List<IEnemyController>();

        public EnemyPool(EnemyManager enemyManager, EnemyData enemyData)
        {
            this.enemyManager = enemyManager;
            this.enemyData = enemyData;

            enemyPool = new ObjectPool<IEnemyController>(CreateEnemyController,
                                                         OnGetEnemyController,
                                                         OnReleaseEnemyController,
                                                         OnDestroyEnemyController);
        }

        public void RequestEnemy()
        {
            IEnemyController controller = enemyPool.Get();
            enemyControllers.Add(controller);
        }

        private IEnemyController CreateEnemyController()
        {
            var controller = new EnemyController(enemyData, enemyManager);
            controller.CreateEnemy();
            return controller;
        }

        private void OnGetEnemyController(IEnemyController controller)
        {
            controller.GetFromPool();
            enemyManager.SetTarget(controller);
        }

        private void OnReleaseEnemyController(IEnemyController controller)
        {
            controller.ReturnToPool();
        }

        private void OnDestroyEnemyController(IEnemyController controller)
        {
            controller.DestroyFromPool();
        }

        public void OnUpdate()
        {
            foreach (var controller in enemyControllers)
            {
                controller.HandleFollowTarget();
                controller.HandleTryAttackTarget();
            }
        }
    }
}