using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletSpeed;

    private Player2D player;
    private SwitchWeapons weapon;

    private void Start()
    {
        player = GetComponent<Player2D>();
        weapon = GetComponent<SwitchWeapons>();
        
    }
    void Update()
    {
        SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();

        if (Input.GetButtonDown("Fire1") && weapon.gun == true)
        {
            GameObject tmp = Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, 0));
            Rigidbody2D tmpRB = tmp.GetComponent<Rigidbody2D>();
            Destroy(tmp, 5f);
            if(playerSprite.flipX == true) //facing left, bullet shoots left
            {
                tmpRB.AddForce(new Vector2(-5, 0) * bulletSpeed); 
            } else
            {
                tmpRB.AddForce(new Vector2(5, 0) * bulletSpeed); //facing right, bullet shoots right
            }
            
     
        }
    }
}
