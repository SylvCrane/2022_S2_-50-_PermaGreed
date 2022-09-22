using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    // I use this to make the variables private, which also shows up in the Editor
    [SerializeField] Healthbar _healthbar;
    [SerializeField] private AudioSource damageSoundEffect;
    [SerializeField] private AudioSource healSoundEffect;

    void Start()
    {
       
    }


    // This is to test health being damage by pressing the 2 keywords
    // When player health goes down to 0 the screen will be redirected to the main menu
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
        if (GameManager.gameManager._playerHealth.GetHealth() <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Pass in how much damage player is going to take
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        // To be able to add the sound effect when player gets hit
        damageSoundEffect.Play();

        if (!DI_System.CheckIfObjectInSight(this.transform))
        {
            DI_System.CreateIndicator(this.transform);
        }
    }

    // Pass in how much healing player is going to take
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        // To be able to add the sound effect when player gets healed
        healSoundEffect.Play();
    }
}
