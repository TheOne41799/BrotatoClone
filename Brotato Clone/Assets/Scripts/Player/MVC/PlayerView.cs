using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Rigidbody2D playerRB;



        public void TestMove(Vector2 velocityVector)
        {
            playerRB.linearVelocity = velocityVector;
        }
    }
}