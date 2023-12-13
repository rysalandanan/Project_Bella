using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    //reference script//
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(HitMarker());
        }
    }
    IEnumerator HitMarker()
    {
        _spriteRenderer.color = new Color(255,0,0);
        yield return new WaitForSeconds(.2f);
        _spriteRenderer.color = new Color(255, 255, 255);
    }
}
