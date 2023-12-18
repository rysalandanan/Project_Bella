using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 RespawnPoint;
    void Start()
    {
        RespawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SavePoint"))
        {
            RespawnPoint = transform.position;
        }
        else if(collision.gameObject.CompareTag("FallDetector"))
        {
            transform.position = RespawnPoint;
        }
    }
}
