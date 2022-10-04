using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class costPrint : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if (GameData.gunRarity == GunStats.Rarity.Common)
        {
            this.gameObject.GetComponent<Text>().text = "$50";
        }
        else if (GameData.gunRarity == GunStats.Rarity.Uncommon)
        {
            this.gameObject.GetComponent<Text>().text = "$100";
        }
        else if (GameData.gunRarity == GunStats.Rarity.Rare)
        {
            this.gameObject.GetComponent<Text>().text = "$200";
        }
        else if (GameData.gunRarity == GunStats.Rarity.Epic)
        {
            this.gameObject.GetComponent<Text>().text = "--";
        }
    }
}
