using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject DialogueScreen;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public bool isPlayerNear;
    public Image DefaultSpeaker;
    public Sprite Speaker;
    public bool isTriggerOnce;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
          isPlayerNear = true;
          textComponent.text = string.Empty;
          StartDialogue();
          SpeakerProfile();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerNear = false;
    }

    private void Update()
    {
        if (Input.anyKeyDown && isPlayerNear)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        DialogueScreen.SetActive(true);
        StartCoroutine(typeLine());
    }
    IEnumerator typeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < lines.Length- 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            DialogueScreen.SetActive(false);
            if(isTriggerOnce)
            {
                Object.Destroy(gameObject);
            }
        }
    }
    private void SpeakerProfile()
    {
        DefaultSpeaker.sprite = Speaker;
    }
}
