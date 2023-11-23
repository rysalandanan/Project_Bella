using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    //reference script//
    public PlayerHealthManager _playerHealthManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            _playerHealthManager.DecreaseHP();
        }
    }
}
