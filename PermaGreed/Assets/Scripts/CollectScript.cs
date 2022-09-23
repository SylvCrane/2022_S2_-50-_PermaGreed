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

    //sound manager
    public GunAudio soundManager;

    //The start function is used to determine if the player will have a weapon equipped or not at the start of the game
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

    //The update function constantly checks for when the player is attempting to collect or drop a weapon
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

    //Picks up an item and places it within the the gun container
    public void collect()
    {
        //The equipped and full variables are set too true to prevent the character from being able to hold 2 or more guns at one
        equipped = true;
        this.gameObject.GetComponent<DefaultGun>().updateCurrentOnce = true;
        full = true;

        //The gun is set to a child of the gun container and obtains its position 
        transform.SetParent(gunContainer);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        //The following code changes the rotation of the gun depending on what it is
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

        // rigidbody and collider are set to true so the gun maintains it's position, the gun script is then enabled so the gun can be used
        rb.isKinematic = true;
        co.isTrigger = true;
        gun.enabled = true;
    }

    private void drop()
    {
        //allows the player to pickup another game
        equipped = false;
        full = false;

        //removes the gun as a child of the game container object
        transform.SetParent(null);

        //frees the position of the gun and allows it to move freely 
        rb.isKinematic = false;
        co.isTrigger = false;

        //add forces to the weapon as it's dropped, this prevents the weapon from falling straight downwards
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * ForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * UpwardForce, ForceMode.Impulse);

        //the gun is disabled
        gun.enabled = false;
    }
}
