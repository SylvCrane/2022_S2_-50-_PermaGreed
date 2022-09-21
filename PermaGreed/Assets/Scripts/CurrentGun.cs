using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGun : MonoBehaviour
{
    Sprite currentGun;

    void Start()
    {
        if (GameData.gunName == null)
        {
            GameData.gunName = "Revolver";
        }

        Debug.Log(GameData.gunName);

        currentGun = Resources.Load<Sprite>(GameData.gunName);

        if (currentGun == null)
        {
            Debug.Log("There is no gun loaded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = currentGun;
    }
}
