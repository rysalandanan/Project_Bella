using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShowEnding : MonoBehaviour
{
    public GameObject EndingPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowEnd());
        }
    }
    private IEnumerator ShowEnd()
    {
        EndingPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
