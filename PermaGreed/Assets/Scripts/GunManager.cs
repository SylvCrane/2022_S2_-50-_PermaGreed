using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    //This script is used to replace the gun the player is currently holding if they upgraded the gun in the upgrades menu.

    //This will access the player's gun container to access guns.
    public GameObject gunContainer;

    //This will be called if the player has upgraded the gun, it holds all of the potential gun combinations in the game currently.
    public GameObject guns;

    //This will be used to call the correct gun by name.
    string newGunName;

    //The gun that needs to be replaced
    GameObject gunToReplace;

    //The replacement gun
    GameObject replacementGun;
    public GameObject player;

    bool differentGunChange = true;

    public void resetInputManager()
    {
        gunToReplace = gunToReplace = gunContainer.transform.GetChild(0).gameObject;
        player.GetComponent<InputManager>().gun = gunToReplace;
        player.GetComponent<InputManager>().gunSwitch = true;
    }

    void Update()
    {
        //This will check if teh guncontainer has a child object, being a gun.
        try
        {
            if (gunContainer.transform.GetChild(0) != null)
            {
                //assign to gunToReplace
                gunToReplace = gunContainer.transform.GetChild(0).gameObject;

                //If the gun is found to be different, it will replace it.
                if (gunToReplace.GetComponent<DefaultGun>().gunName != GameData.gunName)
                {
                    if (differentGunChange)
                    {
                        Debug.Log("You shouldn't be seeing this, you sneaky snoo...");

                        string newGunNamePartial = GameData.gunName;
                        newGunName = newGunNamePartial + GameData.gunRarity;

                        replacementGun = guns.transform.Find(newGunName).gameObject;
                        replacementGun.GetComponent<CollectScript>().collect();
                        //replacementGun.transform.parent = gunContainer.transform;
                        
                        replacementGun.SetActive(true);
                        GameObject.Destroy(gunToReplace);

                        player.GetComponent<InputManager>().gun = replacementGun;
                        player.GetComponent<InputManager>().gunSwitch = true;

                        differentGunChange = false;
                    }
                }
                else if (gunToReplace.GetComponent<DefaultGun>().gunRarity != GameData.gunRarity)
                {
                    Debug.Log("A difference was found!");

                    string newGunNamePartial = gunToReplace.GetComponent<DefaultGun>().gunName;
                    Debug.Log(newGunNamePartial);
                    newGunName = newGunNamePartial + GameData.gunRarity;
                    Debug.Log(newGunName);

                    //Finding the new gun and making it active
                    replacementGun = guns.transform.Find(newGunName).gameObject;
                    replacementGun.SetActive(true);

                    //Setting the replacement gun to be a child of the gunContainer
                    replacementGun.transform.parent = gunContainer.transform;
                    GameObject.Destroy(gunToReplace);

                    //Making sure the Shoot() function still works when a gun is replaced
                    player.GetComponent<InputManager>().gun = replacementGun;
                    player.GetComponent<InputManager>().gunSwitch = true;

                }
            }
        }
        catch (System.Exception e)
        {

        }

        differentGunChange = false;
        
    }

 
}
