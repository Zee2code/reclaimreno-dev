using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
    public Text textComponent;
    public float delay = 0.5f; // Delay between words
    private Coroutine typeCoroutine;

    public void StartTypewriter(string text)
    {
        if (typeCoroutine != null)
            StopCoroutine(typeCoroutine);

        typeCoroutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string fullText)
    {
        textComponent.text = "";

        foreach (char letter in fullText)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }
}
