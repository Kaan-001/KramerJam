using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    public float bulletSpeed = 50, bulletLifeTime = 2f;
    private GameObject playerPosition;
    
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        GunMovement();

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void GunMovement()
    {
        transform.position = playerPosition.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)playerPosition.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (angle < 90 && angle > 0 || angle < 0 && angle > -90)
        {
            transform.GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    void Shoot()
    {
        // BUG: Mouse imleci karaktere yakýn olursa mermi hýzlý gitmiyor olduðu yere düþüyor.

        
        GameObject bulletx = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletx.GetComponent<Rigidbody2D>().AddForce(bulletx.transform.right*bulletSpeed,ForceMode2D.Impulse);
         
        Destroy(bulletx, bulletLifeTime);
    }
}