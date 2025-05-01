using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ World Item/ World Item", fileName = "World Item")]
    public class WorldItem : ScriptableObject
    {
        [SerializeField] private WorldItemType worldItemType;
        [SerializeField] private Vector2 minMaxQuantity;
        private int quantity;

        public WorldItemType WorldItemType => worldItemType;
        public Vector2 MinMaxQuantity => minMaxQuantity;
        public int Quantity => quantity;
    }
}