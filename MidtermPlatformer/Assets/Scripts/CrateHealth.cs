using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Instantiate(health, this.gameObject.transform.position, Quaternion.Euler(0,0,0)) ;
            Destroy(this.gameObject);
            
        }
    }
}
