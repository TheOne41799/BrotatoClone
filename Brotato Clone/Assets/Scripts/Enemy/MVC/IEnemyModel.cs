using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyModel
    {
        Vector2 CalculateVelocity(Vector2 targetLocation, Vector2 enemyLocation);
        bool TryAttack(Vector2 targetLocation, Vector2 enemyLocation);
    }
}