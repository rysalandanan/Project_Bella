using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Transform targetObject;
    private void Update()
    {
        transform.position = new Vector2 (targetObject.position.x, transform.position.y);
    }
}
