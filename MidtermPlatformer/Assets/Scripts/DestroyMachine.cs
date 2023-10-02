using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMachine : MonoBehaviour
{
    // Start is called before the first frame update

    private int machineHealth = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (machineHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            machineHealth--;
        }
    }
}
