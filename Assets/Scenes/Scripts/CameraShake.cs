using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.1f;
    public float strength = 0.2f;
    public int vibrato = 10, vibratoMin = 1;
    public static CameraShake instance;
    private void Start()
    {
        StartCoroutine(ShakeRoutine());
        instance = this;
    }
    public float shakeIntervalMin = 0.1f;  // Min bekleme s�resi
    public float shakeIntervalMax = 0.3f;  // Max bekleme s�resi

  
   
    IEnumerator ShakeRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(shakeIntervalMin, shakeIntervalMax);
            yield return new WaitForSeconds(waitTime);

            // Salla ama �ok hafif
            transform.DOComplete(); // �nceki varsa iptal et
            transform.DOShakePosition(duration, strength/2, vibratoMin, 90f, false, true);
        }
    }
    public void Shake()
    {
        transform.DOComplete(); // �nceki sars�nt� varsa iptal et
        transform.DOShakePosition(duration, strength, vibrato, 90f, false, true);
    }
}