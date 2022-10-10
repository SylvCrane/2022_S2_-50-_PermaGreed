using UnityEngine;
using UnityEngine.UI;

public class ScreenSetting : MonoBehaviour
{
    public static FullScreenMode screenModeConfig;
    public Toggle gameToggle;

    public void WindowedMode() //Uses dynamic bool
    {
        bool windowToggle = gameToggle.GetComponent<Toggle>().isOn;
        //Debug.Log(windowToggle);

        if(windowToggle) //If this is true..
        {
            screenModeConfig = FullScreenMode.Windowed;
        }
        else
        {
            screenModeConfig = FullScreenMode.FullScreenWindow;
        }
    }
}
