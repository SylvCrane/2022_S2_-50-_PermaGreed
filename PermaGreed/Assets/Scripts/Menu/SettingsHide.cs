using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHide : MonoBehaviour
{
    public GameObject GraphicsBar;
    public GameObject AudioBar;
    public GameObject ControlsBar;

    //Buttons
    public Button GraphicButton;
    public Button AudioButton;
    public Button ControlsButton;

    public void GraphicsTrue()
    {
        GraphicButton.interactable = false;
        AudioButton.interactable = true;
        ControlsButton.interactable = true;

        GraphicsBar.SetActive(true);
        AudioBar.SetActive(false);
        ControlsBar.SetActive(false);
    }

    public void AudioTrue()
    {
        
    }


}
