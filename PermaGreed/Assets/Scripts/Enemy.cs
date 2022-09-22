using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //This script will be called by the DefaultGun and attached to the enemies such that they can be killed with the gun.

    public float health = 30f;
    public PlayerBalance balance;

    public void healthDown(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Destroy(gameObject);
            balance.AddCount();
        }
    }
}
