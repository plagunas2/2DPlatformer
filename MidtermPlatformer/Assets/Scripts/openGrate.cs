using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.CollabMigration;
using UnityEngine;

public class openGrate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject grate;
    private SpriteRenderer sprite;

    private Collider2D grateColl;
    
    void Start()
    {
        //grate = GetComponent<GameObject>();
        sprite = grate.GetComponent<SpriteRenderer>();
        grateColl = grate.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && grateColl == true)
        {
            grateColl.enabled = false;
            sprite.flipX = true;
            
        }
    }
}
