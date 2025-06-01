using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    public AudioSource MenuAudio;
    public AudioClip open, close;
    // Start is called before the first frame update
   public void OnMenu() 
    {
        MenuAudio.PlayOneShot(open);
    }
    public void CloseMenu() 
    {
        MenuAudio.PlayOneShot(close);
    }
}
