using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class KeyManager : MonoBehaviour
{
    public Image ScreenOpened;
    void Start()
    {
        ScreenOpened.DOFade(0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
