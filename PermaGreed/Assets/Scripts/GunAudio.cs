using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour
{
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
