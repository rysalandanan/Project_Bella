using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 RespawnPoint;
    public GameObject DeathScreen;
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
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
            //transform.position = RespawnPoint;
        }
        else if(collision.gameObject.CompareTag("Trap"))
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
            //transform.position = RespawnPoint;
        }
    }
    public void RespawnButton()
    {
        transform.position = RespawnPoint;
    }
}
