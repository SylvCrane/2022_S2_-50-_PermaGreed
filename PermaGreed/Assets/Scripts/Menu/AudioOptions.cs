using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro; //For the musicText and musicSound

public class AudioOptions : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicOption;
    [SerializeField] Slider soundOption;
     
    public TMP_InputField musicText;
    public TMP_InputField musicSound;

    const string MUSIC_MIXER = "MusicMixer";
    const string SOUND_MIXER = "SoundMixer";

    void Awake()
    {
        musicOption.onValueChanged.AddListener(ChangeMusic);
        musicOption.onValueChanged.AddListener(VisualText);
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

    void VisualText(float musicVal)
    {
        musicText.text = (musicVal * 100) + "";
    }

}
