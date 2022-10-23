using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenSetting : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionBar;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionBar.ClearOptions(); //Clear any options before adding anything in 

        List<string> OptionsLists = new List<string>();

        int indexCurrent = 0;
        for(int q = 0; q < resolutions.Length; q++)
        {
            string compatOption = resolutions[q].width + "x" + resolutions[q].height;
            OptionsLists.Add(compatOption);

            if(resolutions[q].width == Screen.currentResolution.width && resolutions[q].height == Screen.currentResolution.height)
            {
                indexCurrent = q;
            }
        }

        resolutionBar.AddOptions(OptionsLists);
        //Setting the resolution to the current computers resolution
        resolutionBar.value = indexCurrent;
        resolutionBar.RefreshShownValue();
    }

    public void SetResolution(int indexLocate)
    {
        Resolution resolutionVal = resolutions[indexLocate];
        Screen.SetResolution(resolutionVal.width, resolutionVal.height, Screen.fullScreen);
    }

    public void WindowedMode(bool windowToggle) //Windowed Mode
    {
        Screen.fullScreen = windowToggle;
    }




}
