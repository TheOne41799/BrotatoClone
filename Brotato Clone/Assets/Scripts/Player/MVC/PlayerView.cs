using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Rigidbody2D playerRB;

        private IPlayerViewObserver playerController;
        private Vector2 velocity;

        public void SetDependencies(IPlayerViewObserver playerController)
        {
            this.playerController = playerController;
        }

        public void Move(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        private void FixedUpdate()
        {
            playerRB.linearVelocity = velocity;

            playerController.HandlePlayerStatus(this.transform.position);
        }
    }
}