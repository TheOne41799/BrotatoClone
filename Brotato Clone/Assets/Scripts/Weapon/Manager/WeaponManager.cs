using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace BrotatoClone.Weapon
{
    public class WeaponManager : MonoBehaviour, IManager
    {
        [SerializeField] private TestWeaponData testWeaponData;

        private IEventManager eventManager;

        private Queue<Action> weaponQueue = new Queue<Action>();

        private TestWeaponController controller;

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
            eventManager.PlayerEvents.OnWeaponRequested.AddListener(OnWeaponRequested);
        }

        private void CreateControllers()
        {
            controller = new TestWeaponController(testWeaponData, this);
        }

        private void DisposeControllers()
        {

        }

        private void Update()
        {
            if (controller != null) controller.OnUpdate();
        }

        public void HandleEnemyHit(DamageDisplayData damageDisplayData)
        {
            eventManager.WeaponEvents.OnEnemyHit.Invoke(damageDisplayData);
        }

        public WeaponSpawnData OnWeaponTransformRequested()
        {
            WeaponSpawnData weaponSpawnData = new WeaponSpawnData(controller.OnWeaponTransformRequested());
            return weaponSpawnData;
        }

        public void OnWeaponRequested()
        {
            Debug.Log("Weapon Requested by player");

            if (IsWeaponAvailable())
            {
                SpawnWeapon();
            }
            else
            {
                QueueWeaponRequest();
            }
        }

        private void SpawnWeapon()
        {            
            if (weaponQueue.Count > 0)
            {
                weaponQueue.Dequeue()?.Invoke();
            }
        }

        private bool IsWeaponAvailable()
        {
            // Logic for checking if the weapon is available
            return true;
        }

        private void QueueWeaponRequest()
        {
            weaponQueue.Enqueue(SpawnWeapon);
        }
    }
}