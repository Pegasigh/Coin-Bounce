using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SFXPlayer : MonoBehaviour
{
    public AudioSource click;
    public AudioSource confirm;

    public void PlayClick()
    {
        click.Play();
    }

    public void PlayConfirm()
    {
        confirm.Play();
    }
}
