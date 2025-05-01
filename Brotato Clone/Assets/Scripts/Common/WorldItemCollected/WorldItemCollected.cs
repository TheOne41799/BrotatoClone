using UnityEngine;

namespace BrotatoClone.Common
{
    public struct WorldItemCollected
    {
        public WorldItemType WorldItemType;
        public int Quantity;

        public WorldItemCollected(WorldItemType type, int Quantity)
        {
            this.WorldItemType = type;
            this.Quantity = Quantity;
        }
    }
}