using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    [SerializeField] GunStats stats;
    [SerializeField] GunStats currentGun;
    public Camera cam;
    public GameObject impactEffect;
    public ParticleSystem muzzle;

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
    GameObject rarityRectangle;
    public bool updateCurrentOnce;

    float TimeSinceFire;
    private bool gunAvailable() => !currentGun.reload && TimeSinceFire > 1f / (currentGun.fireRate / 60f);

    public Material common;
    public Material uncommon;
    public Material rare;
    public Material epic;

    public void Start()
    {
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

        if (transform.parent != null)
        {
            setToCurrent();
        }
        
        setRarityofRarityRectangle();
    }

    void setToCurrent()
    {
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
        if (transform.parent != null)
        {
            Debug.Log("The shoot function is persumably working as intended");

            RaycastHit hit;

            if ((currentGun.tempAmmo > 0) && (gunAvailable()))
            {
                muzzle.Play();

                Debug.Log(currentGun.tempAmmo);

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, currentGun.range))
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        enemy.healthDown(currentGun.damage);
                    }


                    Debug.Log(hit.transform.name);
                }

                currentGun.tempAmmo--;
                TimeSinceFire = 0;
            }
            else if (currentGun.tempAmmo == 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void Update()
    {
        if ((transform.parent != null) && (this.gameObject.GetComponent<CollectScript>().equipped) && (updateCurrentOnce))
        {
            setToCurrent();
            updateCurrentOnce = false;
        }

        TimeSinceFire += Time.deltaTime;
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        currentGun.reload = true;
        yield return new WaitForSeconds(currentGun.reloadDuration);
        currentGun.tempAmmo = currentGun.ammoCount;
        currentGun.reload = false;
        Debug.Log("Done!");
    }
}
