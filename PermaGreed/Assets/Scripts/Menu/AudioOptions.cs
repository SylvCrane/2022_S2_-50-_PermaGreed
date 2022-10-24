using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicOption;
    [SerializeField] Slider soundOption;

    const string MUSIC_MIXER = "MusicMixer";
    const string SOUND_MIXER = "SoundMixer";

    void Awake()
    {
        musicOption.onValueChanged.AddListener(ChangeMusic);
        soundOption.onValueChanged.AddListener(ChangeSound);
    }

    void ChangeMusic(float musicValue)
    {
        mixer.SetFloat(MUSIC_MIXER, Mathf.Log10(musicValue) * 20);
        //Keep in mind, AudioMixer is in logarithmic (0.0001 to 10,000) while slider is linear (-5 to 5)
    }
    
    void ChangeSound(float musicValue)
    {
        mixer.SetFloat(SOUND_MIXER, Mathf.Log10(musicValue) * 20);
    }

}
