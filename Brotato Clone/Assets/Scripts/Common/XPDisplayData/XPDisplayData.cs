using UnityEngine;

namespace BrotatoClone.Common
{
    public struct XPDisplayData
    {
        public float XPBarRatio;
        public int Level;

        public XPDisplayData(float XPBarRatio, int Level)
        {
            this.XPBarRatio = XPBarRatio;
            this.Level = Level;
        }
    }
}