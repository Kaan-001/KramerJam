using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    public bool canspawn;
    public GameObject[] enemyPrefabs;
    public float spawnDelay = 1f;
    public LayerMask wallLayer;
    public float effectBeforeSpawnDelay = 0.8f;
    public float checkRadius = 3f,countNow=0;
    public GameObject spawnWarningPrefab;
    public float zDepth = 0f; // spawn'ın z pozisyonu

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
     
    }

    public IEnumerator SpawnLoop()
    {
        if (!canspawn)
            yield break;
        yield return new WaitForSeconds(1.5f);
        int spawnAmount = Random.Range(5, 11);
        countNow = 0;

        while (countNow < spawnAmount)
        {
            Vector3 spawnPos = GetRandomPointInCameraView();

            if (!Physics2D.OverlapCircle(spawnPos, checkRadius, wallLayer))
            {
                // ⚠️ Uyarı objesini oluştur
                GameObject warning = Instantiate(spawnWarningPrefab, spawnPos, Quaternion.identity);

                // Başlangıçta 0 scale (görünmez)
               
                // DOTween ile büyüyerek görünür olsun
             
                warning.transform.localScale = Vector3.zero;

                Sequence fxSequence = DOTween.Sequence();

                // 1. Aynı anda scale ve rotasyon yap
                fxSequence.Join(
                    warning.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack)
                );
                fxSequence.Join(
                    warning.transform.DORotate(new Vector3(0f, 0f, 360f), 0.3f, RotateMode.FastBeyond360)
                );

                // Bekleme
                yield return new WaitForSeconds(effectBeforeSpawnDelay);

                // DOTween ile tekrar küçülerek yok olsun
                warning.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack);

                // Küçülme bitince uyarı objesini yok et
                Destroy(warning, 0.25f); // Destroy gecikmeli (animasyon bitince)

                // Düşmanı spawnla
                GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemy, spawnPos, Quaternion.identity);

                countNow += 1;
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(0.05f); // diğer deneme için minik gecikme
        }

        canspawn = false;
    }
    public void ActivateRoom()
    {
            countNow = 0;
            canspawn = true;
            StartCoroutine(SpawnLoop());
        
    }
    Vector3 GetRandomPointInCameraView()
    {
        float randX = Random.Range(0f, 1f);
        float randY = Random.Range(0f, 1f);
        Vector3 viewportPoint = new Vector3(randX, randY, -cam.transform.position.z + zDepth);

        // Viewport'tan world pozisyona çevir
        Vector3 worldPoint = cam.ViewportToWorldPoint(viewportPoint);
        worldPoint.z = zDepth; // 2D oyunlar için z sabitlenir
        return worldPoint;
    }
}