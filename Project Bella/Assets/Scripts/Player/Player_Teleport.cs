using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Teleport : MonoBehaviour
{
    private bool isTeleporting;

    private GameObject TargetPlayer;
    public GameObject TP_Animation;
    private Vector2 TP_Location;
    private void Start()
    {
        TargetPlayer = GameObject.Find("Player");
    }
    private void OnEnable()
    {
        isTeleporting = true;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        isTeleporting = false;
    }

    private void Update()
    {
        if(isTeleporting)
        {
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;

            if(Input.GetMouseButtonDown(0))
            {
                TP_Location = transform.position;
                StartCoroutine(StartTeleport());
            }
            if(Input.GetMouseButtonDown(1))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private IEnumerator StartTeleport()
    {
        Time.timeScale = 0f;
        TP_Animation.transform.position = TargetPlayer.transform.position;
        TP_Animation.SetActive(true);
        TargetPlayer.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSecondsRealtime(1.5f);
        TP_Animation.transform.position = TP_Location;
        TargetPlayer.transform.position = TP_Location;
        yield return new WaitForSecondsRealtime(1.7f);
        TP_Animation.SetActive(false);
        TargetPlayer.GetComponent<Renderer>().enabled = true;
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
