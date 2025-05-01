using UnityEngine;

namespace BrotatoClone.Common
{
    public interface ICollectible
    {
        void OnItemCollected(Transform targetTransform);
    }
}