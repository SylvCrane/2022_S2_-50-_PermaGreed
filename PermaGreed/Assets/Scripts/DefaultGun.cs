using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    [SerializeField] GunStats stats;
    public Camera cam;
    public GameObject impactEffect;
    public ParticleSystem muzzle;

    float TimeSinceFire;
    private bool gunAvailable() => !stats.reload && TimeSinceFire > 1f / (stats.fireRate / 60f);


    public void Shoot()
    {
        Debug.Log("The shoot function is persumably working as intended");
        
        RaycastHit hit;

        if ((stats.tempAmmo > 0) && (gunAvailable()))
        {
            muzzle.Play();

            Debug.Log(stats.tempAmmo);

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, stats.range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.healthDown(stats.damage);
                }


                Debug.Log(hit.transform.name);
            }

            stats.tempAmmo--;
            TimeSinceFire = 0;
        }
        else if (stats.tempAmmo == 0)
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
        stats.reload = true;
        yield return new WaitForSeconds(stats.reloadDuration);
        stats.tempAmmo = stats.ammoCount;
        stats.reload = false;
        Debug.Log("Done!");
    }
}
