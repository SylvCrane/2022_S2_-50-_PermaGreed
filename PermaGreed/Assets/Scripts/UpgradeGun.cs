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
            if (GameData.currency >= 50)
            {
                GameData.gunRarity = GunStats.Rarity.Uncommon;
                Debug.Log(GameData.gunRarity);
                GameData.currency -= 50;
            }
            else
            {
                sendToCannotUpgrade();
            }
        }
        else if (GameData.gunRarity == GunStats.Rarity.Uncommon)
        {
            if (GameData.currency >= 100)
            {
                GameData.gunRarity = GunStats.Rarity.Rare;
                Debug.Log(GameData.gunRarity);
                GameData.currency -= 100;
            }
            else
            {
                sendToCannotUpgrade();
            }
        }
        else if (GameData.gunRarity == GunStats.Rarity.Rare)
        {
            if (GameData.currency >= 200)
            {
                GameData.gunRarity = GunStats.Rarity.Rare;
                Debug.Log(GameData.gunRarity);
                GameData.currency -= 200;
            }
            else
            {
                sendToCannotUpgrade();
            }

            GameData.gunRarity = GunStats.Rarity.Epic;
            Debug.Log(GameData.gunRarity);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Epic)
        {
            //Of course, there is a limit to the upgrades. Therefore, if the player has maxed out their upgrades, the upgradeMenu is set to not active
            //and the cannotUpgradeMenu is set to active. This also occurs when the player does not have enough funds.
            sendToCannotUpgrade();
        }
    }

    public void sendToCannotUpgrade()
    {
        upgradeMenu.SetActive(false);
        cannotUpgradeGunMenu.SetActive(true);
    }
}
