using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardUse : MonoBehaviour
{
    // Start is called before the first frame update

    public Boolean hasKeyCard = false;
    public GameObject door;
    public Boolean test = false;

    private DoorManager doorManager;
    void Start()
    {
        doorManager = door.GetComponent<DoorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "KeyCard") //pick up Key Card
        {
            hasKeyCard = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KeyCardScreen" && hasKeyCard == true && Input.GetKey(KeyCode.E)) //open door to next level
        {
            StartCoroutine(doorManager.OpenDoor());
            //TODO: make sure all machines in the level are destroyed first before opening door to next level
        }
    }
}
