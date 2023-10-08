using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroTextController : MonoBehaviour
{


    public TextMeshProUGUI text;
    public string[] sentences;
    private int index = 0;
    public float textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            text.text = "";
            StartCoroutine(WriteText());
        }
    }
    IEnumerator WriteText()
    {
        foreach (char Character in sentences[index].ToCharArray())
        {
            text.text += Character;
            yield return new WaitForSeconds(textSpeed);
        }
        index++;
    }
}
