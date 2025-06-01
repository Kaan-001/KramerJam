using UnityEngine;


public class Player : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Vector2 MovementSpeed = new Vector2(30.0f, 30.0f);
    private Rigidbody2D rigidbody2Dx;
    public Vector2 inputVector = new Vector2(0.0f, 0.0f);

    private GameObject gunObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2Dx = GetComponent<Rigidbody2D>();
        rigidbody2Dx.angularDrag = 0.0f;
        rigidbody2Dx.gravityScale = 0.0f;

        gunObject = GameObject.FindObjectOfType<Gun>().gameObject;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Move();
        HandleAnimations();
        FlipBasedOnGun();
    }

    public ParticleSystem walkDust;

    void Move()
    {
        Vector2 velocity = new Vector2(inputVector.x * MovementSpeed.x*2, inputVector.y * MovementSpeed.y*2);
        rigidbody2Dx.velocity = velocity;

        // Yürüme efekti kontrolü
        if (velocity.magnitude > 0.01f)
        {
            if (!walkDust.isPlaying)
                walkDust.Play();
        }
        else
        {
            if (walkDust.isPlaying)
                walkDust.Stop();
        }
    }

    void HandleAnimations()
    {
        if (inputVector != Vector2.zero)
            animator.Play("Run");
        else
            animator.Play("Idle");
    }

    void FlipBasedOnGun()
    {
        if (gunObject == null) return;

        float angle = gunObject.transform.rotation.eulerAngles.z;

        // 0-180 arasý sað, 180-360 arasý sol
        if (angle > 90 && angle < 270)
            transform.localScale = new Vector3(-1f, 1f, 1f); // sola bakýyor
        else
            transform.localScale = new Vector3(1f, 1f, 1f);  // saða bakýyor
    }
}