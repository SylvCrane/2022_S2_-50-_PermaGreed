using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefaultGun : MonoBehaviour
{
    //This is used to shoot the gun the player is currently holding. If that gun were to be switched, all of the values will be reset onto the new gun.

    //The ScriptableObject for this gun
    [SerializeField] GunStats stats;

    //The general scriptableObject that is used for the player's current gun.
    [SerializeField] GunStats currentGun;
    public Camera cam;
    public GameObject impactEffect;

    //The muzzle effect
    public ParticleSystem muzzle;

    public TextMeshProUGUI ammoDisplay;

    //These values are representative of the values found in the gun scriptableObjects, as well as some bools.
    public string gunName;
    public int ammoCount;
    public float damage;
    public bool reload;
    public float range;
    public float reloadDuration;
    public bool hasSpread;
    public float fireRate;
    public float tempAmmo;
    public GunStats.Rarity gunRarity;

    //This rectangle will change in colour depending on the rarity of the gun, in cooperation with the materials 
    //seen below.
    GameObject rarityRectangle;
    

    public Material common;
    public Material uncommon;
    public Material rare;
    public Material epic;

    //This updates the gun if it is switched in cooperation with the gun collection script.
    public bool updateCurrentOnce;

    //The time since the gun was shot last; reset to 0 when a bullet is 'fired'.
    float TimeSinceFire;

    //A simple method that checks if the gun can be shot depending on the gun's fireRate.
    private bool gunAvailable() => !currentGun.reload && TimeSinceFire > 1f / (currentGun.fireRate / 60f);

    public void Start()
    {

        //The initial portion of the script being active is assigning all of the values of the gun's assigned scriptableObject to
        //this gun's primitive variables.
        gunName = stats.gunName;
        ammoCount = stats.ammoCount;
        damage = stats.damage;
        reload = stats.reload;
        range = stats.range;
        reloadDuration = stats.reloadDuration;
        hasSpread = stats.hasSpread;
        fireRate = stats.fireRate;
        tempAmmo = stats.tempAmmo;
        gunRarity = stats.gunRarity;


        //If the player is currently holding the gun, the primitive values in this gun are set to the current gun scriptableObject.
        if (transform.parent != null)
        {
            setToCurrent();
        }
        
        //self-explanatory
        setRarityofRarityRectangle();
    }

    void setToCurrent()
    {
        //This will set the values of the primitive variables in this gun to the current gun scriptableObject, which will be accessed by the Shoot() method.
        currentGun.gunName = gunName;
        currentGun.ammoCount = ammoCount;        
        currentGun.damage = damage;
        currentGun.reload = reload;        
        currentGun.range = range;       
        currentGun.reloadDuration = reloadDuration;       
        currentGun.hasSpread = hasSpread;        
        currentGun.fireRate = fireRate;        
        currentGun.tempAmmo = tempAmmo;        
        currentGun.gunRarity = gunRarity;

        rarityRectangle = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
    }

    void setRarityofRarityRectangle()
    {
        //Depending on the rarity of the gun, the rarityRectangle's material is set to the appropriate rarity color.

        if (gunRarity == GunStats.Rarity.Common)
        {
            rarityRectangle.GetComponent<MeshRenderer>().material = common;

            Debug.Log("It worked!");
        }
        else if (gunRarity == GunStats.Rarity.Uncommon)
        {
            rarityRectangle.GetComponent<MeshRenderer>().material = uncommon;
        }
        else if (gunRarity == GunStats.Rarity.Rare)
        {
            rarityRectangle.GetComponent<MeshRenderer>().material = rare;
        }
        else if (gunRarity == GunStats.Rarity.Epic)
        {
            rarityRectangle.GetComponent<MeshRenderer>().material = epic;
        }
    }

    public void Shoot()
    {
        //This function is called by the playerMotor as it needs to be connected to the Shoot playerInput.

        //If the parent is not null, the player has a gun.
        if (transform.parent != null)
        {
            Debug.Log("The shoot function is persumably working as intended");

            //Because this is called only when the gun is called, the variable is declared here.
            RaycastHit hit;

            //If the gun is not between shots and the gun's magazine is not empty...
            if ((currentGun.tempAmmo > 0) && (gunAvailable()))
            {

                //Plays the muzzle particle effect for its appropriate length of time.
                muzzle.Play();

                GetComponent<AudioSource>().Play();

                Debug.Log(currentGun.tempAmmo);

                //If the rayCast hits an object
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, currentGun.range))
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();

                    //If it hits a gameObject that has teh enemy script, that enemy's health goes down.
                    if (enemy != null)
                    {
                        enemy.healthDown(currentGun.damage);
                    }


                    Debug.Log(hit.transform.name);
                }

                //The gun's ammo decreases and the time since the last shot is set to zero.
                currentGun.tempAmmo--;
                TimeSinceFire = 0;
            }
            else if (currentGun.tempAmmo == 0)
            {
                //If the gun's ammmo is empty and teh player attempts to shoot, the gun reloads.
                StartCoroutine(Reload());
            }
        }
    }

    private void Update()
    {
        //This is used when a new gun is picked up, the new variables need to be assigned to the currentGun scriptableObject.

        //If updateCurrentOnce is true, which is only set to true in the CollectScript when the player equips a gun.
        if ((transform.parent != null) && (this.gameObject.GetComponent<CollectScript>().equipped) && (updateCurrentOnce))
        {
            setToCurrent();

            //Set to false so it is not called again unless the player once again switches their gun.
            updateCurrentOnce = false;
        }

        //Increments the time since the last shot.
        TimeSinceFire += Time.deltaTime;

        ammoDisplay.text = currentGun.tempAmmo.ToString();
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");

        //The gun is currently reloading, important for gunAvailable()
        currentGun.reload = true;

        //This will effectively pause this script here until the reload duration passes
        yield return new WaitForSeconds(currentGun.reloadDuration);

        //reloading the gun
        currentGun.tempAmmo = currentGun.ammoCount;
        currentGun.reload = false;
        Debug.Log("Done!");
    }
}
