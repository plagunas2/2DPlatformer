using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMachine : MonoBehaviour
{
    // Start is called before the first frame update

    private int machineHealth = 10;
    SpriteRenderer sprite;
    Color normal;
    public AudioSource audioSource;

    public machineTracker machineTracker;
    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        normal = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (machineHealth <= 0)
        {
            machineTracker.machineAmount -= 1;
            Destroy(this.gameObject);
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            machineHealth--;
            //sprite = this.gameObject.GetComponent<SpriteRenderer>();
            StartCoroutine(damageSprite());
        }
    }

    IEnumerator damageSprite()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.25f);
        sprite.color = normal;
    }
}
