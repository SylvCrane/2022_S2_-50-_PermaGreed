using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace HealthDecreaseTests
{
    public class HealthDecreaseTest
    {
        [UnityTest]
        public IEnumerator HealthDecrease()
        {
            UnitHealth unitHealth = new UnitHealth(100, 100);

            unitHealth.DmgUnit(20);

            yield return new WaitForSeconds(4);

            Assert.AreEqual(80, unitHealth._currentHealth);
        }
    }

}
    