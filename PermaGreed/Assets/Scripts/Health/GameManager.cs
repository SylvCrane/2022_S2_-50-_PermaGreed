using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Stores player health in a GameManager
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);

    void Start()
    {
        
    }

    // This deletes a duplicate GameManager
    void Awake()
    {
        if (string.Compare(GameData.plClass, "sol") == 0)
        {
            double healthboost = _playerHealth._currentMaxHealth * 0.25f;

            _playerHealth._currentHealth += (int)healthboost;
            _playerHealth._currentMaxHealth += (int)healthboost;
        }

        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }

    }

    void start()
    {
        
    }

    void Update()
    {
        Debug.Log(gameManager._playerHealth._currentHealth + " " + gameManager._playerHealth._currentMaxHealth);
    }
}
