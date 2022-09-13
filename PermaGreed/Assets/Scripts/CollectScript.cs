using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    public DefaultGun gun;
    public Rigidbody rb;
    public BoxCollider co;

    public float range;
    public Transform player, gunContainer, cam;

    public bool equipped; //Needed to tell if current gun is equipped
    public static bool full; //needed if to tell if any gun is equipped

    //forces, needed to allow for weapons to drop and not float on ground
    public float ForwardForce, UpwardForce; 

    private void Start()
    {
        if (!equipped)
        {
            gun.enabled = false;
            rb.isKinematic = false;
            co.isTrigger = false;
        }

        if (equipped)
        {
            gun.enabled = true;
            rb.isKinematic = true;
            co.isTrigger = true;
            full = true;
        }
    }

    private void Update()
    {
        Vector3 distance = player.position - transform.position;
        if (!equipped && distance.magnitude <= range && Input.GetKeyDown(KeyCode.E) && !full)
        {
            collect();
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            drop();
        }
    }

    private void collect()
    {
        equipped = true;
        full = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        co.isTrigger = true;

        gun.enabled = true;
    }

    private void drop()
    {
        equipped = false;
        full = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        co.isTrigger = false;

        //add forces
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * ForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * UpwardForce, ForceMode.Impulse);

        gun.enabled = false;
    }
}
