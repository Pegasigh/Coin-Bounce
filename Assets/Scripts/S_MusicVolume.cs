using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class S_MusicVolume : MonoBehaviour
{
    private void Awake()
    {
        getMusicVolume();
    }

    public Slider musicVolumeSlider;
    public AudioMixer audioMixer;
    
    public void setMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    
    public void getMusicVolume()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume");
        musicVolumeSlider.value = volume;
    }
}
