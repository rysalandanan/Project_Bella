using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
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
}
