using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 0.005f;
    public bool flip = true;
    public bool right = true;
    public float offset = 0f;
    public float playerDist = 0f;
    float x;
    public GameObject player;
    public GameObject bullet;
    public float bulletSpeed = 1f;
    int count = 100;

    public AudioSource audioSource;

    public Boolean playerSeen = false;
    public Boolean toTheLeft = false;

    void Start()
    {
        x = transform.position.x;
        transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        count++;
        if (Vector3.Distance(player.transform.position, transform.position) < playerDist && count > 100)
        {
            playerSeen = true;
            count = 0;
        }
        if(playerSeen == true & count == 0)
        {
            audioSource.Play();
            GameObject tmp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            if (player.transform.position.x - transform.position.x > 0.01f) //player to the right of the enemy
            {
                toTheLeft = true; //face enemy to the left (toward player)

            }
            else
            {
                toTheLeft = false; //face enemy to the right (toward player)
            }
            Rigidbody2D tmpRB = tmp.GetComponent<Rigidbody2D>();
            Destroy(tmp, 5f);
            Vector3 direction = player.transform.position - transform.position;
            tmpRB.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
            playerDist = 20;
        }
          
        if(playerSeen == false)
        {

            if (right == true)
            {
                transform.Translate(Vector2.right * speed);
            }
            else
            {
                transform.Translate(Vector2.left * speed);
            }

            if (transform.position.x > x + distance || transform.position.x < x - distance)
            {
                right = !right;
                if (flip == true)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1;
                    transform.localScale = localScale;
                }
            }
        }
    }
}
