using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = gameObject; //This is attached to the game object. https://docs.unity3d.com/ScriptReference/Component-gameObject.html

        var cubeRenderer = GetComponent<Renderer>();

        Color customColor = new Color(0f, 1f, 1f, 1f);

        cubeRenderer.material.SetColor("_Color", customColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
