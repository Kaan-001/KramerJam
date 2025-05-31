using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HandleDash : MonoBehaviour
{
    public LayerMask DashController;
    public Vector2 direction;
    public void DirectionCalculate() 
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
    }
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) { Dashing(); }
    }
    public void Dashing() 
    {
        DirectionCalculate();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,5,DashController);
        if(hit.collider == null) 
        {
            Vector3 targetPosition = transform.position + (Vector3)(direction.normalized * 5f);

            // DOTween ile karakteri 0.1 saniyede hedefe taþý
            transform.DOMove(targetPosition, 0.2f).SetEase(Ease.OutQuad);
        }
        else 
        {
        //burada dash atamasýn ýþýnlanamasýn
        }
    }
}
