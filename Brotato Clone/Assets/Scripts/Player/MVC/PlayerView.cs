using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView, ITarget
    {
        [SerializeField] private Rigidbody2D playerRB;
        private Vector2 velocity;

        public Transform TargetTransform { get; private set; }

        private void Awake()
        {
            TargetTransform = this.transform;
        }

        public void UpdateVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        private void FixedUpdate()
        {
            playerRB.linearVelocity = velocity;
        }
    }
}