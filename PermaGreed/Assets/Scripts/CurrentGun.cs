using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script acts as as the representation of the player's current gun on the Upgrades Menu.
public class CurrentGun : MonoBehaviour
{
    Sprite currentGun;

    void Start()
    {
        //This start menu assigns a default gun to the start menu, which is representative of the gun the player is currently
        //holding. when the currency and enemy death scripts have been implemented, this will be modified to instead pull the 
        //gun the player is currently holding. If the player is not currently holding a gun, this will default to 
        //the revolver preset laid out below.

        GameData.gunName = "Revolver";
        GameData.ammoCount = 6;
        GameData.damage = 10;
        GameData.range = 50;
        GameData.reloadDuration = 2;
        GameData.fireRate = 60;
        GameData.gunRarity = GunStats.Rarity.Common;

        //This as well as the values above call from the static script GameData, which houses all data that needs to be transferred between scenes
        //for the game.
        currentGun = Resources.Load<Sprite>(GameData.gunName);
    }

    // Update is called once per frame
    void Update()
    {
        //This will pull the gun the player is currently holding from the assigned currentGun sprite and assigning it to this image's sprite.
        this.gameObject.GetComponent<Image>().sprite = currentGun;
    }
}
