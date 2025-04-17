using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Rigidbody2D playerRB;

        public void Move(Vector2 direction, float speed)
        {
            playerRB.linearVelocity = new Vector2(direction.x * speed, playerRB.linearVelocity.y);
        }
    }
}