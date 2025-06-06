using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class UIManaging : MonoBehaviour
{
    public Image[] UIelements;
    public Image optionPanel;
    public Image OptionsButton;
    public Image Door1, Door2;
    public RectTransform[] images; // UI Image objeleri
    public float amplitude = 20f;   // Dalgan�n y�ksekli�i
    public float duration = 1f;     // Bir dalga turunun s�resi
    public float delayBetween = 0.1f; // Objeler aras� faz fark�
   
    void Start()
    {
      

        for (int i = 0; i < images.Length; i++)
        {
            StartWave(images[i], i);
        }

    }
    void StartWave(RectTransform img, int index)
    {
        float startY = img.anchoredPosition.y;

        DOTween.To(() => 0f, x => {
            float offsetY = Mathf.Sin((x + index * delayBetween) * Mathf.PI * 2) * amplitude;
            img.anchoredPosition = new Vector2(img.anchoredPosition.x, startY + offsetY);
        }, 1f, duration)
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear);
    }
    public void OpenOptions() 
    {
        StartCoroutine(OpenOptionsRoutine());
    }
    public void CloseOptions() 
    {
        StartCoroutine(ReverseOptionsRoutine());
    }
    public IEnumerator OpenOptionsRoutine()
    {
       
        foreach (var item in UIelements)
        {
            item.transform.DOScale(0, 0.1f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.4f);
        optionPanel.transform.DOScale(1, 1f);
   

        optionPanel.transform.DOLocalMoveX(0, 2f).SetEase(Ease.OutExpo);

    }
    public IEnumerator ReverseOptionsRoutine() 
    {
        optionPanel.DOKill();
        optionPanel.transform.DOScale(0, 2f);
        optionPanel.transform.DOLocalMoveX(-2000, 1f).SetEase(Ease.OutExpo);

        yield return new WaitForSeconds(0.5f);

        foreach (var item in UIelements) 
        {
            item.transform.DOScale(1, 0.2f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    public void ExitButton() 
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        // Kap�lar hedef konuma DOTween ile giderken "�arp��ma hissi" efektiyle gelsin
        Door1.transform.DOLocalMoveX(-480, 1f)
            .SetEase(Ease.OutBounce); // biraz fazla gidip geri gelir (overshoot efekti)

        Door2.transform.DOLocalMoveX(480, 1f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                // 1.2 saniye bekleyip sonra sahne ge�
                DOVirtual.DelayedCall(1.2f, () =>
                {
                    SceneManager.LoadScene(1);
                });
            });
    }


}




