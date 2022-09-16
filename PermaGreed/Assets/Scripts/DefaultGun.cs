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

    float TimeSinceFire;
    private bool gunAvailable() => !currentGun.reload && TimeSinceFire > 1f / (currentGun.fireRate / 60f);

    public void Start()
    {
        gunName = stats.gunName;
        currentGun.gunName = gunName;

        ammoCount = stats.ammoCount;
        currentGun.ammoCount = ammoCount;

        damage = stats.damage;
        currentGun.damage = damage;

        reload = stats.reload;
        currentGun.reload = reload;

        range = stats.range;
        currentGun.range = range;

        reloadDuration = stats.reloadDuration;
        currentGun.reloadDuration = reloadDuration;

        hasSpread = stats.hasSpread;
        currentGun.hasSpread = hasSpread;

        fireRate = stats.fireRate;
        currentGun.fireRate = fireRate;

        tempAmmo = stats.tempAmmo;
        currentGun.tempAmmo = tempAmmo;

        gunRarity = stats.gunRarity;
        currentGun.gunRarity = gunRarity;

        rarityRectangle = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        if (rarityRectangle != null)
        {
            Debug.Log("Yay!");
        }

        setRarityofRarityRectangle();
    }

    void setRarityofRarityRectangle()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("The shoot function is persumably working as intended");
        
        RaycastHit hit;

        if ((currentGun.tempAmmo > 0) && (gunAvailable()))
        {
            muzzle.Play();

            Debug.Log(stats.tempAmmo);

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

    private void Update()
    {
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
