using UnityEngine;

public class HBD_lights_Settings : MonoBehaviour
{
    public GameObject HBD_Lights;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HBD_Lights.SetActive(true);
        }
    }
}
