using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxBG : MonoBehaviour
{
    private float lenght;
    private float startPos;
    [Header("Main Camera Reference")]
    [SerializeField] private GameObject MainCamera;
    
    public float parFX;
    private void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float Temp = (MainCamera.transform.position.x * (1 - parFX));
        float Distance = (MainCamera.transform.position.x * parFX);
        var TranPos = transform.position;
        //var tranPos = transform.position;
        transform.position = new Vector3(startPos + Distance, TranPos.y,TranPos.z);

        if(Temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (Temp < startPos - lenght)
        {
            startPos -= lenght;
        }

    }
}
