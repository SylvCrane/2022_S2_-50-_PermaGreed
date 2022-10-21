using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //This script will be called by the DefaultGun and attached to the enemies such that they can be killed with the gun.

    public float health = 30f;
    public PlayerBalance balance;
    public GameObject damageText;
    public GameObject gun;

    void Start()
    {
        balance = GameObject.FindWithTag("Player").GetComponent<PlayerBalance>(); //getting PlayerBalance script reference to add money
        gun = GameObject.FindWithTag("Guns");
    }

    public void healthDown(float amount)
    {
        health -= amount;
        EnemyDmgNumber indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<EnemyDmgNumber>();
        indicator.SetDamageText(amount);

        if (health <= 0f)
        {
            gunDrop();
            Destroy(gameObject);
            balance.AddCount();
        }
    }

    public void gunDrop()
    {
        int doGunDrop = Random.Range(0, 101);

        if (doGunDrop >= 70)
        {
            GameObject newGunDrop = Instantiate(gun.transform.GetChild(gunRarity()).gameObject);
            newGunDrop.SetActive(true);
            newGunDrop.transform.position = new Vector3(gameObject.transform.position.x, 2f, gameObject.transform.position.z);
        }  
    }

    public int gunRarity() //this will be subjected to heavy change during iteration 2
    {
        int rarity = Random.Range(0, 101);
        int typeOfGun = Random.Range(1, 4);
        int choosenGun = 0;

        if (rarity >= 0 && rarity <= 50) //common
        {
            if(typeOfGun == 1)
            {
                choosenGun = 0;
            }

            if(typeOfGun == 2)
            {
                choosenGun = 4;
            }

            if(typeOfGun == 3)
            {
                choosenGun = 8;
            }
        }

        else if(rarity > 50 && rarity <= 80) //uncommon
        {
            if (typeOfGun == 1)
            {
                choosenGun = 1;
            }

            if (typeOfGun == 2)
            {
                choosenGun = 5;
            }

            if (typeOfGun == 3)
            {
                choosenGun = 9;
            }
        }

        else if (rarity > 80 && rarity <= 99) //rare
        {
            if (typeOfGun == 1)
            {
                choosenGun = 2;
            }

            if (typeOfGun == 2)
            {
                choosenGun = 6;
            }

            if (typeOfGun == 3)
            {
                choosenGun = 10;
            }
        }

        else
        {
            if (typeOfGun == 1)
            {
                choosenGun = 3;
            }

            if (typeOfGun == 2)
            {
                choosenGun = 7;
            }

            if (typeOfGun == 3)
            {
                choosenGun = 11;
            }
        }

        return choosenGun;
    }
}
