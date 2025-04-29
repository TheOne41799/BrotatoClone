using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using BrotatoClone.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class WeaponManager : MonoBehaviour, IManager
    {
        // Handle this later
        //[SerializeField] private MeleeWeaponData meleeWeaponData;


        //This is a test
        [SerializeField] private TestWeaponData testWeaponData;

        private IEventManager eventManager;

        // Handle this later
        //private IWeaponController meleeWeaponController;


        //this is a test
        private TestWeaponController controller;

        public void InitializeManager(IEventManager eventManager)
        {
            SetManagerDependencies(eventManager);
            RegisterEventListeners();
            CreateControllers();
        }

        private void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void RegisterEventListeners()
        {
            
        }

        private void CreateControllers()
        {
            // Handle this later
            //meleeWeaponController = new MeleeWeaponController(meleeWeaponData);



            //this is a test
            controller = new TestWeaponController(testWeaponData, this);
        }

        private void DisposeControllers()
        {

        }

        private void Update()
        {
            //this is a test
            if (controller != null) controller.OnUpdate();
        }

        public void HandleEnemyHit(Vector2 spawnPosition)
        {
            eventManager.WeaponEvents.OnEnemyHit.Invoke(spawnPosition);
        }
    }
}