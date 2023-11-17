using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public SpriteRenderer Health_1;
    public SpriteRenderer Health_2;
    public SpriteRenderer Health_3;
    public Sprite RemovedHealth;
    private int healthCount;
    public GameObject PlayerDownScreen;
    public PlayerManager script;
    void Start()
    {
        healthCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch(healthCount)

        {
            case 2:
                Health_3.sprite = RemovedHealth;
                break;
            case 1:
                Health_2.sprite = RemovedHealth;
                break;
            case 0:
                Health_1.sprite = RemovedHealth;
                break;
                
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            healthCount--;
            CheckHealth();
        }
    }
    private void CheckHealth()
    {
        if(healthCount == 0)
        {
            script.PlayerDown();
            ShowDownScreen();
        }
        
    }
    private void ShowDownScreen()
    {
        PlayerDownScreen.SetActive(true);
    }
    public void PlayerRevived()
    {
        script.PlayerRevived();
        healthCount = 3;

    }
}
