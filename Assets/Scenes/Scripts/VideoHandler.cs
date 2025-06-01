using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;
public class VideoHandler : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public Image fadeImage; // UI Image for fading
    public float fadeDuration = 1.5f;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Ekraný yavaþça karart
        fadeImage.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            // Fade tamamlandýktan sonra sahne geç
            SceneManager.LoadScene(nextSceneName);
        });
    }
}
