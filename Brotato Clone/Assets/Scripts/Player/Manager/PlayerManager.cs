using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerManager : MonoBehaviour, IManager
    {
        [SerializeField] private PlayerData playerData;

        private IEventManager eventManager;

        private IPlayerController playerController;

        public void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;


            CreateController();
        }

        private void CreateController()
        {
            playerController = new PlayerController(playerData.PlayerViewPrefab);
        }

        private void DisposeController()
        {

        }
    }
}