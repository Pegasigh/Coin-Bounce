using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UISound : MonoBehaviour
{
    private UniversalAudioPlayer player;

    private void Start()
    {
        player = FindObjectOfType<UniversalAudioPlayer>();
    }
    public void PlayClick()
    {
        player.PlayClick();
    }
    public void PlayConfirm()
    {
        player.PlayConfirm();
    }
}
