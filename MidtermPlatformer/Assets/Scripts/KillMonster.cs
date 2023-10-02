using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillMonster : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
