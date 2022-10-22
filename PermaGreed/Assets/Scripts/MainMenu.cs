using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This is the script used to transfer between scenes and quit the game.
    public void PlayButton()
    {
        GameData.plClass = "sol";

        //Because of how the scenes are ordered in the Build settings, this assigns the current scene to the Game, as it is the value of 1.

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
