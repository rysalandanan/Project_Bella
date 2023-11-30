using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private float lenght;
    private float startPos;
    public GameObject MainCamera;
    public float parFX;
    private void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float temp = (MainCamera.transform.position.x * (1 - parFX));
        float dist = (MainCamera.transform.position.x * parFX);
        //var tranPos = transform.position;
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (temp < startPos - lenght)
        {
            startPos -= lenght;
        }

    }
}
