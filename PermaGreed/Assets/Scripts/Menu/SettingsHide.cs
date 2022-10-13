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
        GraphicButton.interactable = true;
        AudioButton.interactable = false;
        ControlsButton.interactable = true;

        AudioBar.SetActive(true);
        ControlsBar.SetActive(false);
        GraphicsBar.SetActive(false);
    }

    public void ControlsTrue()
    {
        GraphicButton.interactable = true;
        AudioButton.interactable = true;
        ControlsButton.interactable = false;

        AudioBar.SetActive(false);
        GraphicsBar.SetActive(false);
        ControlsBar.SetActive(true);
    }


}
