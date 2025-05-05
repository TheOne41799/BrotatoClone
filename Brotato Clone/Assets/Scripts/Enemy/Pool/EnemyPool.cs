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

        private ObjectPool<EnemyController> enemyPool;
        private List<EnemyController> enemyControllers = new List<EnemyController>();

        public EnemyPool(EnemyManager enemyManager, EnemyData enemyData)
        {
            this.enemyManager = enemyManager;
            this.enemyData = enemyData;

            enemyPool = new ObjectPool<EnemyController>(CreateEnemyController,
                                                         OnGetEnemyController,
                                                         OnReleaseEnemyController,
                                                         OnDestroyEnemyController);
        }

        public void RequestEnemy()
        {
            EnemyController controller = enemyPool.Get();
            if (!enemyControllers.Contains(controller))
            {
                enemyControllers.Add(controller);
            }
        }

        public void ReleaseEnemy(EnemyController controller)
        {
            enemyPool.Release(controller);
        }

        private EnemyController CreateEnemyController()
        {
            var controller = new EnemyController(enemyData, enemyManager);
            controller.CreateEnemy();
            return controller;
        }

        private void OnGetEnemyController(EnemyController controller)
        {
            controller.GetFromPool();
            enemyManager.SetTarget(controller);
        }

        private void OnReleaseEnemyController(EnemyController controller)
        {
            controller.ReturnToPool();
        }

        private void OnDestroyEnemyController(EnemyController controller)
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