using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] GameObject DownScreen;
    public  bool isInputEnabled;

    private void Update()
    {
        if(DownScreen.activeSelf)
        {
            Time.timeScale = 0f;
            isInputEnabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            isInputEnabled = true;
        }    
    }
}
