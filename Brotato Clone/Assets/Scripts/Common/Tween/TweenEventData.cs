using UnityEngine;

namespace BrotatoClone.Common
{
    public struct TweenEventData
    {
        public TweenType tweenType;
        public GameObject target;
        public object payload;

        public TweenEventData(TweenType tweenType, GameObject target, object payload)
        {
            this.tweenType = tweenType;
            this.target = target;
            this.payload = payload;
        }
    }
}