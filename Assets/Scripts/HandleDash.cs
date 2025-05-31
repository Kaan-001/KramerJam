using System.Collections;
using UnityEngine;

public class HandleDash : MonoBehaviour
{
    // FIX: Dash çalýþmýyor

    public float dashCooldown = 1.0f;
    public float dashDuration = 0.2f;
    public float dashSpeed = 10.0f;

    private float dashTimer = 0.0f;
    private bool isDashing = false;

    public Player player;

    void Update()
    {
        // Dash input
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PerformDash();
        }

        if (isDashing == true)
        {
            dashCooldown -= Time.deltaTime;
        }
    }

    private IEnumerator PerformDash()
    {
        Vector2 dashDirection = player.inputVector;

        Debug.Log(dashDirection);

        // Eðer hareket yoksa dash yapma
        if (dashDirection == Vector2.zero)
            yield break;
        else
        {
            isDashing = true;

            player.rigidbody2D.velocity = dashDirection * dashSpeed;
        }    

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }
}
