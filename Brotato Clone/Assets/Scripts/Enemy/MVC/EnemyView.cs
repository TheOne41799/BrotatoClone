using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView, IDamageable
    {
        private IViewObserver enemyController;

        [SerializeField] private Rigidbody2D enemyRB;
        private Vector2 velocity;

        public void SetController(IViewObserver enemyController)
        {
            this.enemyController = enemyController;
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }

        public void Move(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        private void FixedUpdate()
        {
            enemyRB.linearVelocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageable>(out var damageable))
            {
                enemyController.OnDispose();

                Destroy(this.gameObject);
            }
        }
    }
}