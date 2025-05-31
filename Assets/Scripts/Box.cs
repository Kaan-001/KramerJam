using DG.Tweening;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isDestroyed = false;
    private int HealthCurrent=2;

    [Header("Can prefablarý (0. index: Can)")]
    public GameObject[] Prefabs;
    public Sprite Broken;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet") && !isDestroyed)
        {
            HealthCurrent -= 1;

            if (HealthCurrent <= 0) 
            {
                if (Random.value <= 0.5f && Prefabs.Length > 0)
                {
                    GameObject spawnedObj = Instantiate(Prefabs[0], transform.position, Quaternion.identity);

                    Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 2f));
                    Vector3 jumpTarget = transform.position + (Vector3)randomOffset;

                    spawnedObj.transform.DOJump(jumpTarget, 1.5f, 1, 0.5f).SetEase(Ease.OutQuad);
                }
                isDestroyed = true;
                Destroy(gameObject);
            }
            else 
            {
               
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Broken;
            }

        }
    }
}
