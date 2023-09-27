using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletSpeed;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject tmp = Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, 0));
            Rigidbody2D tmpRB = tmp.GetComponent<Rigidbody2D>();
            Destroy(tmp, 5f);

                tmpRB.AddForce(new Vector2(5, 0) * bulletSpeed);
     
        }
    }
}
