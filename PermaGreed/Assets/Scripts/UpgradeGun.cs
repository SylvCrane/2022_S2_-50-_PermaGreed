using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGun : MonoBehaviour
{
    //This is used for the Upgrade button, effective a more complicated version of the isPressed() method in the inspector.
    public GameObject upgradeMenu;
    public GameObject cannotUpgradeGunMenu;

    //This method is called whenever the player pressed the upgrade button.
    public void upgradeButton()
    {
        //When the button is pressed, the rarity of the gun is updated in gameData. Because of the updating rarityIndicator, the change is instantaneous.
        if (GameData.gunRarity == GunStats.Rarity.Common)
        {
            GameData.gunRarity = GunStats.Rarity.Uncommon;
            Debug.Log(GameData.gunRarity);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Uncommon)
        {
            GameData.gunRarity = GunStats.Rarity.Rare;
            Debug.Log(GameData.gunRarity);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Rare)
        {
            GameData.gunRarity = GunStats.Rarity.Epic;
            Debug.Log(GameData.gunRarity);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Epic)
        {
            //Of course, there is a limit to the upgrades. Therefore, if the player has maxed out their upgrades, the upgradeMenu is set to not active
            //and the cannotUpgradeMenu is set to active.
            upgradeMenu.SetActive(false);
            cannotUpgradeGunMenu.SetActive(true);
        }
    }
}
