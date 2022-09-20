using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject gunContainer;
    public GameObject guns;
    string newGunName;
    GameObject gunToReplace;
    GameObject replacementGun;
    public GameObject player;

    

    void Update()
    {
        if (gunContainer.transform.GetChild(0) != null)
        {
            gunToReplace = gunContainer.transform.GetChild(0).gameObject;

            if (gunToReplace.GetComponent<DefaultGun>().gunRarity != GameData.gunRarity)
            {
                Debug.Log("A difference was found!");

                string newGunNamePartial = gunToReplace.GetComponent<DefaultGun>().gunName;
                Debug.Log(newGunNamePartial);
                newGunName = newGunNamePartial + GameData.gunRarity;
                Debug.Log(newGunName);
                
                replacementGun = guns.transform.Find(newGunName).gameObject;
                replacementGun.SetActive(true);

                replacementGun.transform.parent = gunContainer.transform;
                GameObject.Destroy(gunToReplace);

                player.GetComponent<InputManager>().gun = replacementGun;
                player.GetComponent<InputManager>().gunSwitch = true;

            }
        }
    }

 
}
