using UnityEngine;

namespace BrotatoClone.Common
{
    public struct TweenScalePingPongData
    {
        public Vector3 targetScale;
        public float duration;
        public int loopCount;

        public TweenScalePingPongData(Vector3 targetScale, float duration, int loopCount)
        {
            this.targetScale = targetScale;
            this.duration = duration;
            this.loopCount = loopCount;
        }
    }
}