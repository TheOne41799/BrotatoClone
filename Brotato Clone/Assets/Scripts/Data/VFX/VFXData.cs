using BrotatoClone.VFX;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ VFX Data", fileName = "VFX Data")]
    public class VFXData : ScriptableObject
    {
        [SerializeField] private DamageText damageTextPrefab;

        public DamageText DamageTextPrefab => damageTextPrefab;
    }
}