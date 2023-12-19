using System.Collections;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Vector3 ThrowVector;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private LineRenderer lr;

    private GameObject TargetPlayer;
    public float TimeTillDestroy;

    private GameObject TP_VFX;
 
    private void OnEnable()
    {
        rb2D.gravityScale = 0f;
        TargetPlayer = GameObject.Find("Player");
        TP_VFX = TargetPlayer.transform.GetChild(0).gameObject;

        gameObject.GetComponent<Collider2D>().isTrigger = true;
        gameObject.GetComponent<Renderer>().enabled = true;
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
            StartCoroutine(PlayerTP());
        }
    }
    private IEnumerator PlayerTP()
    {
        Time.timeScale = 0f;
        TP_VFX.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = false;
        TargetPlayer.GetComponent<Renderer>().enabled = false;
        var LandingLocation = transform.position;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        yield return new WaitForSecondsRealtime(1f);
        TargetPlayer.transform.position = LandingLocation;
        yield return new WaitForSecondsRealtime(2.5f);
        TP_VFX.SetActive(false);
        TargetPlayer.GetComponent<Renderer>().enabled = true;
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
