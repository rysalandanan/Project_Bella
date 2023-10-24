using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //initial spawn point at start//
        RespawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SavePoint"))
        {
            //set spawn point//
            RespawnPoint = transform.position;
        }
        else if(collision.gameObject.CompareTag("FallDetector"))
        {
            transform.position = RespawnPoint;
        }
    }
}
