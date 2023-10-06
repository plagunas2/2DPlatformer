using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextController : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI text;
    public string[] sentences;
    private int index = 0;
    public float textSpeed;
    void Start()
    {
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextSentence()
    {
        if(index <= sentences.Length-1)
        {
            text.text = "";
            StartCoroutine(WriteText());
        }
    }
    IEnumerator WriteText()
    {
        foreach(char Character in sentences[index].ToCharArray())
        {
            text.text += Character;
            yield return new WaitForSeconds(textSpeed);
        }
        index++;
    }
}
