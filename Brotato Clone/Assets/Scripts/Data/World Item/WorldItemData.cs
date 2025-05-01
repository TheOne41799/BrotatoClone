using BrotatoClone.WorldItem;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ World Item/ World Item Data", fileName = "World Item Data")]
    public class WorldItemData : ScriptableObject
    {
        [Header("Currency One Item")]
        [SerializeField] private WorldItem currencyOneItemData;
        [SerializeField] private CurrencyOneItemView currencyOneItemViewPrefab;
        public WorldItem CurrencyOneItemData => currencyOneItemData;
        public CurrencyOneItemView CurrencyOneItemViewPrefab => currencyOneItemViewPrefab;

        [Header("Currency Two Item")]
        [SerializeField] private WorldItem currencyTwoItemData;
        [SerializeField] private CurrencyTwoItemView currencyTwoItemViewPrefab;
        public WorldItem CurrencyTwoItemData => currencyTwoItemData;
        public CurrencyTwoItemView CurrencyTwoItemViewPrefab => currencyTwoItemViewPrefab;
    }
}