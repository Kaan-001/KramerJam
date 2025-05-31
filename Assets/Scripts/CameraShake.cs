using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.1f;
    public float strength = 0.2f;
    public int vibrato = 10;
    public static CameraShake instance;
    private void Start()
    {
        instance = this;
    }
    public void Shake()
    {
        transform.DOComplete(); // önceki sarsýntý varsa iptal et
        transform.DOShakePosition(duration, strength, vibrato, 90f, false, true);
    }
}