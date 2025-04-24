using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour, IPlayerView, ITarget, IDamageable
    {
        [SerializeField] private Rigidbody2D playerRB;
        private Vector2 velocity;

        public Transform TargetTransform { get; private set; }

        private void Awake()
        {
            TargetTransform = this.transform;
        }

        public void Move(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        private void FixedUpdate()
        {
            playerRB.linearVelocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
    }
}