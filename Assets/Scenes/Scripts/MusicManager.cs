using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introMusic; // Ýlk çalacak müzik
    public AudioClip loopMusic;  // Döngüsel müzik

    void Start()
    {
        StartCoroutine(PlayIntroThenLoop());
    }

    private IEnumerator PlayIntroThenLoop()
    {
        // Intro müziðini çal
        audioSource.clip = introMusic;
        audioSource.loop = false;
        audioSource.Play();

        // Müziðin bitmesini bekle
        yield return new WaitForSeconds(introMusic.length);

        // Loop müziðini çal ve döngüye al
        audioSource.clip = loopMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
