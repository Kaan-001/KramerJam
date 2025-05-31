using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float health = 100;
    public Vector2 MovementSpeed = new Vector2(20.0f, 20.0f); // 2D Movement speed to have independant axis speed
    public Rigidbody2D rigidbody2D;
    public Vector2 inputVector = new Vector2(0.0f, 0.0f);

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        // If RequireComponent is used uncomment the GetComponent and comment the AddComponent out
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        // Rigidbody2D affects physics so any ops on it should happen in FixedUpdate
        // See why here: https://learn.unity.com/tutorial/update-and-fixedupdate#
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }
}