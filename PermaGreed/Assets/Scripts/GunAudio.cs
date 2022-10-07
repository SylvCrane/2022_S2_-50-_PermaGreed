using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour
{
    //This script stores refernce to all of the sounds the gun needs, this is so to make managing multiple sounds easier
    public AudioSource ASfire;
    public AudioSource ASdrop;
    public AudioSource ASpickup;

    public void playFire()
    {
        ASfire.Play();
    }

    public void playDrop()
    {
        ASdrop.Play();
    }

    public void playPickup()
    {
        ASpickup.Play();
    }
}
