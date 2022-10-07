using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public deathOperations death;
    // I used this to make the variable private, which also shows up in the Editor
    [SerializeField] Healthbar _healthbar;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource healSound;
    [SerializeField] private AudioSource deathSound;

    void Start()
    {

    }

    // This is to test health being damaged by pressing the 2 keywords
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        // When player health goes down to 0 the screen will be redirected to the main menu to simulate death for the time being
        if (GameManager.gameManager._playerHealth.GetHealth() <= 0)
        {
            deathSound.Play();
            death.whenPlayerDies();
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Pass in player being damaged
    public void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        //To be able to add the sound effect when player gets hit
        damageSound.Play();


        // This starts the damage indicator when player gets hit
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
        //To be able to add the sound effect when player gets healed
        healSound.Play();

    }
}

