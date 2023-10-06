using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushTrap : MonoBehaviour
{
    public bool isActive = false;
    public bool isInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
        }
    }

    void FixedUpdate()
    {
        print(isInside + "" + isActive);
        if (isInside == true && isActive == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void KillOn() {
        isActive = true;
    }

    public void KillOff()
    {
        isActive = false;
    }

}
