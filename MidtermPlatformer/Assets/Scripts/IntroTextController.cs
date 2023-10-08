using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTextController : MonoBehaviour
{


    public TextMeshProUGUI text;
    public string[] sentences;
    private int index = 0;
    public float textSpeed;
    private bool nextText = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //skip cut scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetButtonDown("Fire1") && nextText == true)
        {
            nextText = false;
            NextSentence();
        }

        if(index == sentences.Length && nextText == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
        nextText = true;
    }
}
