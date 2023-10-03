using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{

   // int machineHealth = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrel" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //destroy bullet if it hits walls, etc.
    {
        if (collision.gameObject.tag != "Enemy" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag != "Player" && this.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
        }

        //if (collision.gameObject.tag == "Machine" && this.gameObject.tag == "PlayerBullet")
        //{
          //  SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>();
            //sprite.color = Color.red; //fix this
            //machineHealth += 1;
            //if (machineHealth >=5)
            //{
              //  Destroy(collision.gameObject);
                //machineHealth = 0;
            //}
        //}
    }
}
