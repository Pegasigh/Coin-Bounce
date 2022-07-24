using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UniversalAudioPlayer : MonoBehaviour
{
    //making it universal
    private void Awake()
    {
        //checks how many music players there are
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        //keep this between scenes
        DontDestroyOnLoad(this.gameObject);

        //load up music volume
        loadMusicVolume();
    }


    //audio sources
    public AudioMixer mixer;
    public AudioSource click;
    public AudioSource confirm;


    public void loadMusicVolume()
    {
        float volume;

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            volume = 0.5f;
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void PlayClick()
    {
        click.Play();
    }

    public void PlayConfirm()
    {
        confirm.Play();
    }
}
