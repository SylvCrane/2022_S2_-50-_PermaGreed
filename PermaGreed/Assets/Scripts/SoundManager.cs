using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundManager : MonoBehaviour
{
    //Statics so all objects can access the sounds
    //Gun Sounds
    public static AudioSource s_common;
    public static AudioSource s_uncommon;
    public static AudioSource s_rare;

    //Collect and drops sounds
    public static AudioSource s_ASdrop;
    public static AudioSource s_ASpickup;

    //Non statics that are set using the editor
    //Gun Sounds
    public AudioSource common;
    public AudioSource uncommon;
    public AudioSource rare;

    //Collect and drops sounds
    public AudioSource ASdrop;
    public AudioSource ASpickup;

    void Awake()
    {
        //sets firing sounds
        s_common = common;
        s_uncommon = uncommon;
        s_rare = rare;

        //sets collect sounds
        s_ASdrop = ASdrop;
        s_ASpickup = ASpickup;
    }
}
