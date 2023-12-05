using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public SpriteRenderer Health_1;
    public SpriteRenderer Health_2;
    public SpriteRenderer Health_3;
    public Sprite DamagedHealth;
    private int healthCount;
    public GameObject PlayerDownScreen;

    //reference script//
    [Header("Player script (Animation)")]
    public PlayerAnimation _playerAnimation;
    void Start()
    {
        healthCount = 3;
    }
    void Update()
    {
        switch(healthCount)
        {
            case 2:
                Health_3.sprite = DamagedHealth;
                break;
            case 1:
                Health_2.sprite = DamagedHealth;
                break;
            case 0:
                Health_1.sprite = DamagedHealth;
                break;   
        }
    }
    private void CheckHealth()
    {
        if(healthCount == 0)
        {
            ShowDownScreen();
            _playerAnimation.isDown = true;
        }  
    }
    private void ShowDownScreen()
    {
        PlayerDownScreen.SetActive(true);
    }
    public void PlayerRevived()
    {
        _playerAnimation.isDown = false;
        healthCount = 3;
        PlayerDownScreen.SetActive(false);
    }
    public void DecreaseHP()
    {
        healthCount--;
        CheckHealth();
    }
}
