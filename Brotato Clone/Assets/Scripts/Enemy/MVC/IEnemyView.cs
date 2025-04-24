using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyView
    {
        Vector2 GetPosition();
        void Move(Vector2 velocity);
    }
}