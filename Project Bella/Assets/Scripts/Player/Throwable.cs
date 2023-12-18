using System.Collections;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Vector3 ThrowVector;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private LineRenderer lr;

    private GameObject TargetPlayer;
    public float TimeTillDestroy;

 
    private void OnEnable()
    {
        rb2D.gravityScale = 0f;
        StartCoroutine(DestroyTimer());
        TargetPlayer = GameObject.Find("Player");
    }
    private void OnMouseDown()
    {
        CalculateThrow();
        AimIndicator();
    }
    private void OnMouseDrag()
    {
        CalculateThrow();
        AimIndicator();
    }
    private void CalculateThrow()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePos - this.transform.position;
        ThrowVector = -distance * 100;
    }
    private void AimIndicator()
    {
        lr.positionCount = 2;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, ThrowVector / 2);
        lr.enabled = true;
    }
    private void OnMouseUp()
    {
        rb2D.AddForce(ThrowVector);
        rb2D.gravityScale = 1f;
        AimIndidactorOff();
    }
    private void AimIndidactorOff()
    {
        lr.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("You hit ground");
            TargetPlayer.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(TimeTillDestroy);
        Destroy(gameObject);
    }
}
