using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathOperations : MonoBehaviour
{
    public GameObject gunContainer;
    GameObject playerGun;
    public void whenPlayerDies()
    {
        GameData.currency += this.gameObject.GetComponent<PlayerBalance>().balance;

        try
        {
            if (gunContainer.transform.GetChild(0) != null)
            {
                playerGun = gunContainer.transform.GetChild(0).gameObject;

                GameData.gunName = playerGun.GetComponent<DefaultGun>().gunName;
                GameData.gunRarity = playerGun.GetComponent<DefaultGun>().gunRarity;
            }
            else
            {
                GameData.gunName = null;
            }
        }
        catch (System.Exception e)
        {

        }
       
    }
}
