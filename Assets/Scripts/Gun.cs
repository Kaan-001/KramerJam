using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private float bulletSpeed = 50f, bulletLifeTime = 1f;
    private GameObject playerPosition;
    
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        GunMovement();

        if (Input.GetKeyDown(KeyCode.Space))
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

        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        Destroy(bullet, bulletLifeTime);
    }
}