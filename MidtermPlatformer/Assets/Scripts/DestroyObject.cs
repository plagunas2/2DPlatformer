using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{

   
    private void OnCollisionEnter2D(Collision2D collision) //destroy bullet if it hits walls, etc.
    {
        if (collision.gameObject.tag == "Barrel" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag != "Enemy" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag != "Player" && this.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
        }

    }
}
