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

    public void checkClass()
    {
        if (string.Compare(GameData.plClass, "sol") == 0)
        {
            double healthboost = _playerHealth._currentMaxHealth * 0.25f;

            _playerHealth._currentMaxHealth += (int)healthboost;
            _playerHealth._currentHealth += (int)healthboost;
        }
    }

    // This deletes a duplicate GameManager
    void Awake()
    {
        this.checkClass();

        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }

    }
}
