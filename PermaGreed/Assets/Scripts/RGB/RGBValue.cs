using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //YOU NEED THIS FOR UI/MENU
using TMPro; //YOU NEED THIS FOR TEXTFIELDS (this is not legacy textfields)

public class RGBValue : MonoBehaviour
{
    //public InputField redBox;
    public GameObject redBox;
    public GameObject greenBox;
    public GameObject blueBox;

    public void changeRGBvalue()
    {
        /* Grabbing String values from the input fields */
        string redText = redBox.GetComponent<TMP_InputField>().text;
        string greenText = greenBox.GetComponent<TMP_InputField>().text;
        string blueText = blueBox.GetComponent<TMP_InputField>().text;

        /* Converting String to integers first */
        int redInt = int.Parse(redText);
        int greenInt = int.Parse(greenText);
        int blueInt = int.Parse(blueText);

        /* InputField conversion to Integer */
        //Forgot to mention, 0.001 is because Unity RGB is too dumb to acknowledge whole numbers.
        float redValue = redInt * 0.001f;
        float greenValue = greenInt * 0.001f;
        float blueValue = blueInt * 0.001f;

        //Debug.Log("Red Value: " + redValue);
        //Debug.Log("Green Value: " + greenValue);
        //Debug.Log("Blue Value: " + blueValue);

        /* Creating a color based on the user input */
        Color GunNewColour = new Color(redValue, greenValue, blueValue); //e.g. Color(0.23,)

        /* Now Assigning the value to the GameData */
        GameData.gunColour = GunNewColour;
    }
}
