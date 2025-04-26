using UnityEngine;
using BrotatoClone.UI;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ UI Data", fileName = "UI Data")]
    public class UIData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private UIHUD uiHUDPrefab;

        public UIHUD UIHUDPrefab => uiHUDPrefab;

    }
}