using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTest
{
    [UnityTest]
    public IEnumerator PlayerHealthTest()
    {
        GameData.plClass = "sol";
        GameManager gameManager = new GameManager();

        gameManager.checkClass();

        yield return new WaitForSeconds(1);

        Assert.AreEqual(125, gameManager._playerHealth._currentMaxHealth);
    }
}
