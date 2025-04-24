using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        private IViewObserver enemyController;
        private Vector2 velocity;

        private EnemyData enemyData;

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

        public void SetEnemyData(EnemyData enemyData)
        {
            this.enemyData = enemyData;
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3)(velocity * Time.fixedDeltaTime);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;

            Gizmos.DrawWireSphere(this.transform.position, enemyData.AttackRange);
        }
    }
}