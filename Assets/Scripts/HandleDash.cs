using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HandleDash : MonoBehaviour
{
    public LayerMask DashController;
    public Vector2 direction;
    public bool CanDash = true;
    public void DirectionCalculate() 
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
    }
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift)&& CanDash) { Dashing(); }
    }
    IEnumerator candashing() 
    {
        yield return new WaitForSeconds(1.5f);
        CanDash = true;
    }

    public void Dashing()
    {
        CanDash = false;
        DirectionCalculate();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 5, DashController);

        if (hit.collider == null)
        {
            Vector3 targetPosition = transform.position + (Vector3)(direction.normalized * 5f);

            // DASH EFEKTİ BAŞLANGIÇ
            Sequence dashSequence = DOTween.Sequence();

            // Karakterin scale yönü
            float facingDirection = Mathf.Sign(transform.localScale.x);

            // Dash yönüne göre görsel eğim (örneğin 15 derece)
            float tiltAmount = 15f * -facingDirection;
            // NOT: facingDirection sağa bakıyorsa +1, sola bakıyorsa -1
            // Bu yüzden sola bakarken eğim +15° yerine -15° oluyor

            // 1. Küçül + eğil (eğim scale yönüne göre terslenmiş)
            dashSequence.Append(transform.DOScale(new Vector3(0.8f * facingDirection, 0.8f, 1f), 0.05f));
            dashSequence.Join(transform.DORotate(new Vector3(0f, 0f, tiltAmount), 0.05f));

            // 2. Hedefe hareket
            dashSequence.Append(transform.DOMove(targetPosition, 0.2f).SetEase(Ease.OutQuad));

            // 3. Eski haline dön
            dashSequence.Append(transform.DOScale(new Vector3(facingDirection, 1f, 1f), 0.1f));
            dashSequence.Join(transform.DORotate(Vector3.zero, 0.1f));

            StartCoroutine(candashing());
        }
        else
        {
            // Engel varsa dash atmasın
        }
    }


}
