using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    //How to use:
    //Attach collect script to the gun, make sure the gun has a rigidbody and box collider 
    //Set the rigid body to Extrapolate and Continuous Speculative
    //If the gun is mean't to be equipped by default, make the gun a child of the gun container object and set equipped on the collectscript to true
    //otherwise set it to false and remove it as a child

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

    public void collect()
    {
        equipped = true;
        this.gameObject.GetComponent<DefaultGun>().updateCurrentOnce = true;
        full = true;

        transform.SetParent(gunContainer);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        if (this.gameObject.name.Contains("ScifiHandGun"))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (this.gameObject.name.Contains("semiAutomatic"))
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
            transform.localScale = Vector3.one;
        }
        else if (this.gameObject.name.Contains("Revolver"))
        {
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;
        }

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
