using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class GunTests
{
    [UnityTest]
    public IEnumerator AmmoDecreases()
    {
        GameObject gun = new GameObject();
        GameObject gunParent = new GameObject();

        gun = Object.Instantiate(Resources.Load("RevolverCommon")) as GameObject;

        GameObject player = Object.Instantiate(Resources.Load("Player")) as GameObject;

        gun.gameObject.transform.parent = gunParent.transform;
        gun.gameObject.GetComponent<CollectScript>().player = player.transform;
        gun.gameObject.GetComponent<DefaultGun>().tempAmmo = 6.0f;
        Debug.Log(gun.gameObject.GetComponent<DefaultGun>().tempAmmo);
        gun.SetActive(true);


        yield return new WaitForSeconds(3);

        gun.gameObject.GetComponent<DefaultGun>().Shoot();

        Assert.AreEqual(5.0f, gun.gameObject.GetComponent<DefaultGun>().tempAmmo);

    }
}
