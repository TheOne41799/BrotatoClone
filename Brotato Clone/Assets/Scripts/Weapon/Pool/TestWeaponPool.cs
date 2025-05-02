using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace BrotatoClone.Weapon
{
    public class TestWeaponPool
    {
        private TestWeaponData testWeaponData;
        private WeaponManager weaponManager;
        private ObjectPool<TestWeaponController> testWeaponPool;

        private List<TestWeaponController> activeControllers;

        public TestWeaponPool(TestWeaponData testWeaponData, WeaponManager weaponManager)
        {
            this.testWeaponData = testWeaponData;
            this.weaponManager = weaponManager;

            testWeaponPool = new ObjectPool<TestWeaponController>(CreateController,
                                                                  OnGetController,
                                                                  OnReleaseController,
                                                                  OnDestroyController);

            activeControllers = new List<TestWeaponController>();
        }

        private TestWeaponController CreateController()
        {
            return new TestWeaponController(testWeaponData, weaponManager, this);
        }

        private void OnGetController(TestWeaponController testWeaponController)
        {
            if (!activeControllers.Contains(testWeaponController)) activeControllers.Add(testWeaponController);
            testWeaponController.OnGetFromPool();
        }

        private void OnReleaseController(TestWeaponController testWeaponController)
        {
            if (activeControllers.Contains(testWeaponController)) activeControllers.Remove(testWeaponController);
            testWeaponController.OnReturnToPool();
        }

        private void OnDestroyController(TestWeaponController testWeaponController)
        {
            if (activeControllers.Contains(testWeaponController)) activeControllers.Remove(testWeaponController);
            testWeaponController.OnDestroyFromPool();
        }

        public TestWeaponController Get() => testWeaponPool.Get();

        public void Release(TestWeaponController testWeaponController) => testWeaponPool.Release(testWeaponController);

        public void OnUpdate()
        {
            for (int i = activeControllers.Count - 1; i >= 0; i--)
            {
                var controller = activeControllers[i];

                if (controller == null)
                {
                    activeControllers.RemoveAt(i);
                    continue;
                }

                controller.OnUpdate();
            }
        }
    }
}