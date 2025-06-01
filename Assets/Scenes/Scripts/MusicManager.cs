using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introMusic; // �lk �alacak m�zik
    public AudioClip loopMusic;  // D�ng�sel m�zik

    void Start()
    {
        StartCoroutine(PlayIntroThenLoop());
    }

    private IEnumerator PlayIntroThenLoop()
    {
        // Intro m�zi�ini �al
        audioSource.clip = introMusic;
        audioSource.loop = false;
        audioSource.Play();

        // M�zi�in bitmesini bekle
        yield return new WaitForSeconds(introMusic.length);

        // Loop m�zi�ini �al ve d�ng�ye al
        audioSource.clip = loopMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
