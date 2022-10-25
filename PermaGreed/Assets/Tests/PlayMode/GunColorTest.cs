using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class GunColorTest
{
    [UnityTest]
    public IEnumerator GunWhiteCheck()
    {
        GameData.gunColour = new Color(1f, 1f, 1f, 1f); //White

        yield return new WaitForSeconds(2);

        Assert.AreEqual(Color.white, GameData.gunColour); //Expected , Actual
    }

    [UnityTest]
    public IEnumerator GunRedCheck()
    {
        GameData.gunColour = new Color(1f, 0f, 0f, 1f); //Red

        yield return new WaitForSeconds(2);

        Assert.AreEqual(Color.red, GameData.gunColour); //Expected , Actual
    }

    [UnityTest]
    public IEnumerator GunGreenCheck()
    {
        GameData.gunColour = new Color(0f, 0f, 1f, 1f); //Test Case is blue

        yield return new WaitForSeconds(2);

        Assert.AreEqual(Color.green, GameData.gunColour); //Expecting green, gets actual blue value
    }
}
