using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Text loadingText;
    private string textcontent;
    private int count;

    private void Start()
    {
        textcontent = "";
        count = 0;

        StartCoroutine(nameof(ChangeText));
    }

    IEnumerator ChangeText()
    {
        textcontent = "Loading ";
        count = (count + 1) % 4;

        for(int i = 1; i <= count; i++)        
            textcontent += ". ";

        loadingText.text = textcontent;

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(ChangeText));
        yield break;
    }
}
