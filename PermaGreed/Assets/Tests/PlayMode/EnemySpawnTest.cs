using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.AI;

public class EnemySpawnTest
{
    [UnityTest]
    public IEnumerator EnemyHPOnSpawnTest()
    {
        GameObject enemy = new GameObject();
        GameObject player = Object.Instantiate(Resources.Load("Player")) as GameObject;

        GameObject map = Object.Instantiate(Resources.Load("Enviroment (Map)")) as GameObject;

        map.SetActive(true);
        enemy.SetActive(true);

        enemy = Object.Instantiate(Resources.Load("Melee_Enemy")) as GameObject;
        

        yield return new WaitForSeconds(1);

        Assert.AreEqual(5, enemy.gameObject.GetComponent<Enemy>().health);
    }
}
