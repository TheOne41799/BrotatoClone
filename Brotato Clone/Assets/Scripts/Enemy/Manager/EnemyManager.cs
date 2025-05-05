using BrotatoClone.Camera;
using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.Player;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using BrotatoClone.Game;

namespace BrotatoClone.Enemy
{
    public class EnemyManager : MonoBehaviour, IManager
    {
        [SerializeField] private EnemyData enemyData;

        private IEventManager eventManager;
        private ITarget target;

        private EnemyPool enemyPool;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            CreateEnemyPool();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.GameEvents.OnGameStateUpdated.AddListener(OnGameStateUpdated);
            eventManager.PlayerEvents.OnTargetUpdated.AddListener(ReceiveTargetTransform);
        }

        private void ReceiveTargetTransform(ITarget target)
        {
            this.target = target;
        }

        private void RemoveTargetTransform()
        {
            this.target = null;
        }

        private void CreateEnemyPool()
        {
            enemyPool = new EnemyPool(this, enemyData);
        }

        public void SetTarget(EnemyController controller)
        {
            controller.SetEnemyTarget(target);
        }

        public void RequestEnemy()
        {
            enemyPool.RequestEnemy();
        }

        public void ReleaseEnemy(EnemyController controller)
        {
            enemyPool.ReleaseEnemy(controller);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                RequestEnemy();
            }

            enemyPool?.OnUpdate();
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.IN_GAME)
            {
                RequestEnemy();
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