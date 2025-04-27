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
        [SerializeField] private WeaponData weaponData;

        private IEventManager eventManager;

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
            
        }

        private void DisposeControllers()
        {

        }
    }
}