using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
public class UIManaging : MonoBehaviour
{
    public Image[] UIelements;
    public Image optionPanel;
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
            item.transform.DOScale(0, 0.2f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(0.4f);
        optionPanel.transform.DOScale(1, 1f)
   .OnComplete(() => {
       // Bu blok animasyon bittikten sonra çalýþýr
       optionPanel.transform.DOScale(1.05f, 2f)
      .SetLoops(-1, LoopType.Yoyo);

       // Buraya ne yapmak istiyorsan onu yazarsýn
   });

        optionPanel.transform.DOLocalMoveX(0, 2f).SetEase(Ease.OutExpo);

    }
    public IEnumerator ReverseOptionsRoutine() 
    {
        optionPanel.DOKill();
        optionPanel.transform.DOScale(0, 2f);
        optionPanel.transform.DOLocalMoveX(2000, 1f).SetEase(Ease.OutExpo);

        yield return new WaitForSeconds(0.5f);

        foreach (var item in UIelements) 
        {
            item.transform.DOScale(1, 0.2f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(0.25f);
        }
       
        
   
       // Buraya ne yapmak istiyorsan onu yazarsýn
   

       

    }
}
