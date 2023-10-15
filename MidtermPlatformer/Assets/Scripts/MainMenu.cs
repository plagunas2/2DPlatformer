using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{ 
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        audioSource.clip = clip;
    }
    public void PlayGameClick()
    {
        StartCoroutine(PlayGame());
        
    }

    IEnumerator PlayGame()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("CutScene");
    }
    public void QuitGame()
    {
        audioSource.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }

}
