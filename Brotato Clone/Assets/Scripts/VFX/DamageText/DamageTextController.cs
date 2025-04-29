using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.VFX
{
    public class DamageTextController
    {
        private DamageText damageText;
        public DamageDisplayData DamageDisplayData;

        public DamageTextController(VFXData vfxData, DamageDisplayData damageDisplayData, VFXManager vfxManager)
        {
            this.DamageDisplayData = damageDisplayData;

            damageText = GameObject.Instantiate<DamageText>(vfxData.DamageTextPrefab,
                                                            damageDisplayData.spawnPosition,
                                                            Quaternion.identity,
                                                            vfxManager.transform);

            damageText.SetController(this);
            damageText.PlayDamageTextAnimation();
        }
    }
}