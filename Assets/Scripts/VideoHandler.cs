using System.Collections;
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

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        // Önce ekran siyah olsun
        fadeImage.color = new Color(0, 0, 0, 1);

        // Yavaþça aç (fade-in)
        fadeImage.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            videoPlayer.Play();
        });

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Ekraný karart
        fadeImage.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene(nextSceneName);
        });
    }
}
