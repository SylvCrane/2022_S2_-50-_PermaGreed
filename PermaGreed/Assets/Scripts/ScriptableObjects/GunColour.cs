using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunColour : MonoBehaviour
{
    Renderer modelRenderer;

    void Start()
    {
        modelRenderer = GetComponent<Renderer>();

        //Make sure to enable keywords
        //modelRenderer.material.EnableKeyword("Main_metal");
        Color newValue;

        if (GameData.gunColour != null)
        {
            newValue = GameData.gunColour;
            modelRenderer.material.SetColor("_Color", newValue);
        }
    }

}
