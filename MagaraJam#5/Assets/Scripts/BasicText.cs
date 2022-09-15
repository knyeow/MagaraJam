using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BasicText : MonoBehaviour
{
    [SerializeField] [TextArea]
    private string text;

    private TextMeshProUGUI textMesh;

    [SerializeField]
    private float timeBeforeWord;
    private void Start()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
        StartCoroutine(writeText());
    }

    private IEnumerator writeText()
    {
        foreach (char item in text)
        {
            yield return new WaitForSeconds(timeBeforeWord);
            textMesh.text += item;
        }
    }
}
