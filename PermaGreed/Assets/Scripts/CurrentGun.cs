using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGun : MonoBehaviour
{
    Sprite currentGun;

    void Start()
    {

        GameData.gunName = "Revolver";
        GameData.ammoCount = 6;
        GameData.damage = 10;
        GameData.range = 50;
        GameData.reloadDuration = 2;
        GameData.fireRate = 60;
        GameData.gunRarity = GunStats.Rarity.Common;

        
        currentGun = Resources.Load<Sprite>(GameData.gunName);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = currentGun;
    }
}
