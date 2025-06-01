using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private float bulletSpeed = 30f, bulletLifeTime =1f, bulletDelay = 0.4f, nextShootTime = 0f;
    private GameObject playerPosition;
    public GameObject particle;
    public float anglex;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        GunMovement();

        if (Input.GetMouseButtonDown(0) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + bulletDelay;
        }
    }

    void GunMovement()
    {
        transform.position = playerPosition.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)playerPosition.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        anglex = angle;

        if (angle < 90 && angle > 0 || angle < 0 && angle > -90)
            transform.GetComponent<SpriteRenderer>().flipY = false;
        else
            transform.GetComponent<SpriteRenderer>().flipY = true;
    }

    void Shoot()
    {
        // mermiyi anglex rotasyonu ile oluştur
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, anglex-90);

        GameObject bulletx = Instantiate(bulletPrefab, firePoint.position, bulletRotation);

        // mermiyi yönüne doğru fırlat
        bulletx.GetComponent<Rigidbody2D>().AddForce(bulletx.transform.up * bulletSpeed, ForceMode2D.Impulse);

        // kamera salla
        CameraShake.instance.Shake();

        // belirli süre sonra mermiyi yok et
        Destroy(bulletx, bulletLifeTime);

        // particle efekti çalıştır
        particle.GetComponent<ParticleSystem>().Play();
    }
}