using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyView
    {
        void SetController(IViewObserver enemyController);
        Vector2 GetPosition();
        void Move(Vector2 velocity);
    }
}