using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

public class Box : MonoBehaviour
{
    public bool isDestroyed = false;
    public int healthAward = 10;
    public int healthBox,MaxHealthBox=2;

    public GameObject[] Prefabs;
    

    private void Start()
    {
        healthBox = MaxHealthBox;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            healthBox -= 1;
            if (healthBox <= 0)
            {
                // Box kýrýlýr
                int randomVariable = Random.Range(0, Prefabs.Length);
                GameObject spawnedObj = Instantiate(Prefabs[randomVariable], transform.position, Quaternion.identity);

                // Yakýn bir pozisyona doðru rastgele bir hedef belirle
                Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 2f));
                Vector3 jumpTarget = transform.position + (Vector3)randomOffset;

                // DOTween ile zýplama efekti (yüksekliði 1.5, süresi 0.5 saniye, 1 sýçrama)
                spawnedObj.transform.DOJump(jumpTarget, 1.5f, 1, 0.5f).SetEase(Ease.OutQuad);

                // Kutuyu yok et
                Destroy(this.gameObject, 0.4f);
            }
        }
    }
}
