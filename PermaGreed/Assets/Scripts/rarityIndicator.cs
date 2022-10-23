using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is used to show the current rarity of the gun the player is using in the Upgrades Menu, note the calls to gameData.
public class rarityIndicator : MonoBehaviour
{

    //This will be the text printed to the screen.
    Text currentRarity;

    // Update is called once per frame
    void Update()
    {
        currentRarity = this.gameObject.GetComponent<Text>();

        Debug.Log(GameData.gunRarity);

        if (GameData.gunRarity == GunStats.Rarity.Common)
        {
            //The values of the text and the color are set according to the GameData rarity.
            this.gameObject.GetComponent<Text>().text = "Common";
            this.gameObject.GetComponent<Text>().color = new Color(255, 255, 255);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Uncommon)
        {
            this.gameObject.GetComponent<Text>().text = "Uncommon";
            this.gameObject.GetComponent<Text>().color = new Color(0, 152, 255);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Rare)
        {
            this.gameObject.GetComponent<Text>().text = "Rare";
            this.gameObject.GetComponent<Text>().color = new Color(237, 0, 255);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Epic)
        {
            this.gameObject.GetComponent<Text>().text = "Epic";
            this.gameObject.GetComponent<Text>().color = new Color(255, 175, 0);
        }
        else if (GameData.gunRarity == GunStats.Rarity.Legendary)
        {
            this.gameObject.GetComponent<Text>().text = "Legendary";
            this.gameObject.GetComponent<Text>().color = new Color(255, 154, 0);
        }
    }
}
