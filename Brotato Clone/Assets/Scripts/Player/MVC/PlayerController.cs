using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerController : IPlayerController
    {
        public PlayerController(PlayerView playerViewPrefab) 
        {
            IPlayerView view = GameObject.Instantiate<PlayerView>(playerViewPrefab);
        }
    }
}