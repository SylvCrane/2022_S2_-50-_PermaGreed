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

        Color cyan = new Color(0f, 1f, 1f, 1f);
        modelRenderer.material.SetColor("_Color", cyan);
    }

    // Update is called once per frame
    void Update() //This will be used once the RGB colour is implemeneted. (Through the menu or inventory etc.)
    {
        //Insert Parameters
    }
}
