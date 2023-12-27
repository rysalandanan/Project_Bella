using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartStory());
    }
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator StartStory()
    {
        yield return new WaitForSecondsRealtime(5f);
        this.gameObject.SetActive(false);
    }
}
