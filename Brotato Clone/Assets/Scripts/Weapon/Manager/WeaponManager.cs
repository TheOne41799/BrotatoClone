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

        private TestWeaponPool testWeaponPool;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            CreateWeaponPools();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            eventManager.PlayerEvents.OnWeaponRequested.AddListener(OnWeaponRequested);
        }

        private void CreateWeaponPools()
        {
            testWeaponPool = new TestWeaponPool(testWeaponData, this);
        }

        private void DisposeControllers()
        {

        }

        private void Update()
        {
            testWeaponPool.OnUpdate();
        }

        public void OnWeaponRequested(WeaponType weaponType)
        {
            switch(weaponType)
            {
                case WeaponType.TEST:
                    TestWeaponController controller = testWeaponPool.Get();
                    Transform weaponTransform = controller.OnWeaponTransformRequested();

                    WeaponSpawnData weaponSpawnData = new WeaponSpawnData(weaponTransform);
                    eventManager.WeaponEvents.OnWeaponCreated.Invoke(weaponSpawnData);
                    break;
            }
        }

        public void HandleEnemyHit(DamageDisplayData damageDisplayData)
        {
            eventManager.WeaponEvents.OnEnemyHit.Invoke(damageDisplayData);
        }
    }
}