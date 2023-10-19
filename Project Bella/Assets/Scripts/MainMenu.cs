using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public float waitTime;
    public void PlayButton()
    {
        StartCoroutine(GoPlay());
    }

    private IEnumerator GoPlay()
    {
        yield return new WaitForSeconds(waitTime);
        Menu.SetActive(false);
    }
}
