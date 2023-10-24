using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform ExitPosition;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
       // if(other.gameObject.CompareTag ("Player"))
        //{
           other.transform.position = new Vector2(ExitPosition.position.x, ExitPosition.position.y);
            Debug.Log("Teleporting");
        //}
        
    }
}
