using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ControlSettings : MonoBehaviour
{
    public Slider controlSlider;
    public TMP_InputField InputField;

    void Start()
    {
        controlSlider.onValueChanged.AddListener(ControlBoxChange);
        GameData.GameSenstivity = controlSlider.value;
    }

    void Awake()
    {
        //When the player is returning back to the menu
        if (GameData.GameSenstivity != 0f)
        {
            controlSlider.value = GameData.GameSenstivity;
            InputField.text = GameData.GameSenstivity + "";
        }
    }

    public void ControlBoxChange(float ControlValue)
    {
        InputField.text = ControlValue + "";
        GameData.GameSenstivity = ControlValue;
    }
}
