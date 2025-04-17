using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Rigidbody2D playerRB;

        public void Move(Vector2 velocity)
        {
            playerRB.linearVelocity = velocity;
        }
    }
}