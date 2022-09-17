using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ProfessorScene : MonoBehaviour
{
    [SerializeField]
    private Image black;

    [SerializeField]
    private GameObject AnnaText;

    [SerializeField]
    private GameObject ProfessorText;

    private void Start()
    {
        StartCoroutine(PlayTexts());
    }
    private void FixedUpdate()
    {
        black.color -= new Color(0, 0, 0, .01f);
    }

    private IEnumerator PlayTexts()
    {
        yield return new WaitForSeconds(1);
        AnnaText.SetActive(true);
        yield return new WaitForSeconds(50);
        ProfessorText.SetActive(true);
    }

  
}
