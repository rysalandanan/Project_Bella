using System.Collections;
using UnityEngine;

public class Camera_Switch : MonoBehaviour
{
    public GameObject Cam_1;
    public GameObject Cam_2;
    public GameObject HBD_Lights;
    public GameObject d3;
    private bool isSwitched;

    private void Start()
    {
        isSwitched = false;
        Cam_1.SetActive(true);
        Cam_2.SetActive(false);
    }

    private void Update()
    {
        if(HBD_Lights.activeInHierarchy && !isSwitched)
        {
            StartCoroutine(CameraSwitch());
        }
    }
    private IEnumerator CameraSwitch()
    {
        Cam_1.SetActive(false);
        Cam_2.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1f;
        isSwitched = true;
        Cam_1.SetActive(true);
        Cam_2.SetActive(false);
        d3.SetActive(true);
    }
}
