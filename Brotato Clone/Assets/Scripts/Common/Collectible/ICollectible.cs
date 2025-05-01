using UnityEngine;

namespace BrotatoClone.Common
{
    public interface ICollectible
    {
        void HandleItemCollected(Transform targetTransform);
    }
}