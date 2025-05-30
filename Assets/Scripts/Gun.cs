using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject playerPosition; 
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        GunMovement();
    }

    void GunMovement()
    {
        transform.position = playerPosition.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
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
}