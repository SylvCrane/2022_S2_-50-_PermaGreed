using UnityEngine;
using UnityEngine.UI; //YOU NEED THIS FOR UI/MENU
using TMPro; //YOU NEED THIS FOR TEXTFIELDS (this is not legacy textfields)

public class RGBValue : MonoBehaviour
{
    /* RGBValues - This is used in the RGB within the Canvas for gun customization. */
    public Slider redBox;
    public Slider greenBox;
    public Slider blueBox;

    public TMP_InputField redInput;
    public TMP_InputField greenInput;
    public TMP_InputField blueInput;

    public void changeRGBvalue()
    {
        /* Grabbing Float from the Slider */
        float redValue = redBox.value;
        float greenValue = greenBox.value;
        float blueValue = blueBox.value;

        /* Float Calculation */
        redValue = redValue / 255f;
        greenValue = greenValue / 255f;
        blueValue = blueValue / 255f;

        //Debug.Log("Red Value: " + redValue);
        //Debug.Log("Green Value: " + greenValue);
        //Debug.Log("Blue Value: " + blueValue);

        /* Creating a color based on the user input */
        Color GunNewColour = new Color(redValue, greenValue, blueValue, 1f); //e.g. Color(0.23,)

        /* Now Assigning the value to the GameData */
        GameData.gunColour = GunNewColour;
    }

    void Start()
    {
        //So that the red slider connects with the input fields.
        redBox.onValueChanged.AddListener(InputSliderMergeRed);
        greenBox.onValueChanged.AddListener(InputSliderMergeBlu);
        blueBox.onValueChanged.AddListener(InputSliderMergeGrn);

        if (!GameData.gunColour.Equals(Color.clear)) //If the values are not set.
        {
            Debug.Log("Yes, RGB values are returned");

            Color previousCol = GameData.gunColour;

            float previousColRed = previousCol.r * 255f;
            float previousColBlue = previousCol.b * 255f;
            float previousColGreen = previousCol.g * 255f;

            redBox.value = previousColRed;
            greenBox.value = previousColGreen;
            blueBox.value = previousColBlue;

            redInput.text = previousColRed + "";
            greenInput.text = previousColGreen + "";
            blueInput.text = previousColBlue + "";
        }
    }

    public void InputSliderMergeRed(float rgbVar)
    {
        redInput.text = rgbVar + "";
    }

    public void InputSliderMergeBlu(float rgbVar)
    {
        greenInput.text = rgbVar + "";
    }

    public void InputSliderMergeGrn(float rgbVar)
    {
        blueInput.text = rgbVar + "";
    }


}
