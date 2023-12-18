using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportPlayerTP_Orb : MonoBehaviour 
{
    public GameObject TP_Orb;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(TP_Orb,transform.position +(transform.forward *2),transform.rotation);
        }
    }
}
   
