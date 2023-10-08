using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

    
{
    private int healthAmount = 3;
    public Boolean hasKeyCard;
    public GameObject keyCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            if(hasKeyCard == true)
            {
                Instantiate(keyCard, transform.position, Quaternion.Euler(0,0,0));
            }
            Destroy(this.gameObject);
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            takeDamage();
            Destroy(collision.gameObject);
        }
    }

    void takeDamage()
    {
        healthAmount -= 1;
    }
}
