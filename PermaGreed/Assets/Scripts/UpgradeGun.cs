using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGun : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject cannotUpgradeGunMenu;

    public void upgradeButton()
    {
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
            upgradeMenu.SetActive(false);
            cannotUpgradeGunMenu.SetActive(true);
        }
    }
}
