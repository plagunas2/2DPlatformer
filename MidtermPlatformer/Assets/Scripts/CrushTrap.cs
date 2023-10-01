using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushTrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Player2D player = other.GetComponent<Player2D>();

        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
