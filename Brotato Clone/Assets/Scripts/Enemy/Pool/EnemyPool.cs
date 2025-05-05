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

        public void TestFunction()
        {
            CreateEnemyController();
        }

        private IEnemyController CreateEnemyController()
        {
            IEnemyController enemyController = new EnemyController(enemyData, enemyManager);
            enemyController.CreateEnemy();
            enemyManager.SetTarget(enemyController);
            enemyControllers.Add(enemyController);
            return enemyController;
        }

        private void OnGetEnemyController(IEnemyController enemyController)
        {
            enemyController.GetFromPool();
        }

        private void OnReleaseEnemyController(IEnemyController enemyController)
        {
            enemyController.ReturnToPool();
        }

        private void OnDestroyEnemyController(IEnemyController enemyController)
        {
            enemyController.DestroyFromPool();
        }

        public void OnUpdate()
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
    }
}