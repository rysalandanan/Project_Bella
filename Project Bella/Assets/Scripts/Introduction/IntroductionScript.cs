using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScript : MonoBehaviour
{
    public GameObject Intro_1;
    public GameObject Intro_2;
    public float waitTime;
    

    private void Start()
    {
        StartCoroutine(ShowIntro());
    }
    private IEnumerator ShowIntro()
    {
        Intro_1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Intro_1.SetActive(false);
        Intro_2.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }
        

}
