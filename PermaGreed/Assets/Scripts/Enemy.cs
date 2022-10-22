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
        int typeOfGun = Random.Range(1, 13);
        int choosenGun = 0;

        if (rarity >= 0 && rarity <= 50) //common
        {
            choosenGun = commonSelector(typeOfGun);
        }
        else if(rarity > 50 && rarity <= 80) //uncommon
        {
            choosenGun = uncommonSelector(typeOfGun);
        }
        else if (rarity > 80 && rarity <= 99) //rare
        {
            choosenGun = rareSelector(typeOfGun);
        }
        else
        {
            int legendaryChange = Random.Range(0, 100);

            if (legendaryChange == 99)
            {
                choosenGun = legendarySelector(typeOfGun);
            }
            else
            {
                choosenGun = epicSelector(typeOfGun);
            }
        }

        return choosenGun;
    }

    public int commonSelector(int typeOfGun)
    {
        int choosenGun = 0;

        //Pistol
        if (typeOfGun == 1)
        {
            choosenGun = 0;
        }

        if (typeOfGun == 2)
        {
            choosenGun = 4;
        }

        if (typeOfGun == 3)
        {
            choosenGun = 8;
        }

        //Assault Rifles
        if (typeOfGun == 4)
        {
            choosenGun = 12;
        }

        if (typeOfGun == 5)
        {
            choosenGun = 16;
        }

        if (typeOfGun == 6)
        {
            choosenGun = 20;
        }

        //Shotguns
        if (typeOfGun == 7)
        {
            choosenGun = 24;
        }

        if (typeOfGun == 8)
        {
            choosenGun = 28;
        }

        if (typeOfGun == 9)
        {
            choosenGun = 32;
        }

        //Sniper Rifles
        if (typeOfGun == 10)
        {
            choosenGun = 36;
        }

        if (typeOfGun == 11)
        {
            choosenGun = 40;
        }

        if (typeOfGun == 12)
        {
            choosenGun = 44;
        }

        return choosenGun;
    }

    public int uncommonSelector(int typeOfGun)
    {
        int choosenGun = 0;

        //Pistol
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

        //Assault Rifles
        if (typeOfGun == 4)
        {
            choosenGun = 13;
        }

        if (typeOfGun == 5)
        {
            choosenGun = 17;
        }

        if (typeOfGun == 6)
        {
            choosenGun = 21;
        }

        //Shotguns
        if (typeOfGun == 7)
        {
            choosenGun = 25;
        }

        if (typeOfGun == 8)
        {
            choosenGun = 29;
        }

        if (typeOfGun == 9)
        {
            choosenGun = 33;
        }

        //Sniper Rifles
        if (typeOfGun == 10)
        {
            choosenGun = 37;
        }

        if (typeOfGun == 11)
        {
            choosenGun = 41;
        }

        if (typeOfGun == 12)
        {
            choosenGun = 45;
        }

        return choosenGun;
    }

    public int rareSelector(int typeOfGun)
    {
        int choosenGun = 0;

        //Pistol
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

        //Assault Rifles
        if (typeOfGun == 4)
        {
            choosenGun = 14;
        }

        if (typeOfGun == 5)
        {
            choosenGun = 18;
        }

        if (typeOfGun == 6)
        {
            choosenGun = 22;
        }

        //Shotguns
        if (typeOfGun == 7)
        {
            choosenGun = 26;
        }

        if (typeOfGun == 8)
        {
            choosenGun = 30;
        }

        if (typeOfGun == 9)
        {
            choosenGun = 34;
        }

        //Sniper Rifles
        if (typeOfGun == 10)
        {
            choosenGun = 38;
        }

        if (typeOfGun == 11)
        {
            choosenGun = 42;
        }

        if (typeOfGun == 12)
        {
            choosenGun = 46;
        }

        return choosenGun;
    }

    public int epicSelector(int typeOfGun)
    {
        int choosenGun = 0;

        //Pistol
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

        //Assault Rifles
        if (typeOfGun == 4)
        {
            choosenGun = 15;
        }

        if (typeOfGun == 5)
        {
            choosenGun = 19;
        }

        if (typeOfGun == 6)
        {
            choosenGun = 23;
        }

        //Shotguns
        if (typeOfGun == 7)
        {
            choosenGun = 27;
        }

        if (typeOfGun == 8)
        {
            choosenGun = 31;
        }

        if (typeOfGun == 9)
        {
            choosenGun = 35;
        }

        //Sniper Rifles
        if (typeOfGun == 10)
        {
            choosenGun = 39;
        }

        if (typeOfGun == 11)
        {
            choosenGun = 43;
        }

        if (typeOfGun == 12)
        {
            choosenGun = 47;
        }

        return choosenGun;
    }

    public int legendarySelector(int typeOfGun)
    {
        int choosenGun = 0;

        if ((typeOfGun >= 1) && (typeOfGun <= 3))
        {
            choosenGun = 48;
        }

        if ((typeOfGun >= 4) && (typeOfGun <= 6))
        {
            choosenGun = 49;
        }

        if ((typeOfGun >= 7) && (typeOfGun <= 9))
        {
            choosenGun = 50;
        }

        if ((typeOfGun >= 10) && (typeOfGun <= 11))
        {
            choosenGun = 51;
        }

        return choosenGun;
    }
}


