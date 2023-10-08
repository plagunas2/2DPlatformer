using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCardUse : MonoBehaviour
{
    // Start is called before the first frame update

    public Boolean hasKeyCard = false;
    public GameObject door;
    public Boolean test = false;

    private DoorManager doorManager;
    public machineTracker machineTracker;

    public TextMeshProUGUI keyCardWarning; 
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
        if (collision.gameObject.tag == "KeyCardScreen" && hasKeyCard == true && Input.GetKey(KeyCode.E) && machineTracker.machineAmount == 0) //open door to next level
        {
            Debug.Log("test1");
            StartCoroutine(doorManager.OpenDoor());
        }
        if(collision.gameObject.tag == "KeyCardScreen" && hasKeyCard == false && Input.GetKey(KeyCode.E))
        {
            Debug.Log("test2");
            StartCoroutine(cardWarning());
        }
        if(collision.gameObject.tag == "KeyCardScreen" && hasKeyCard == true && Input.GetKey(KeyCode.E) && machineTracker.machineAmount != 0)
        {
            Debug.Log("test3");
            StartCoroutine(machineWarning());
        }
    }

    IEnumerator cardWarning()
    {
        keyCardWarning.text = "Key Card Required";
        yield return new WaitForSeconds(2);
        keyCardWarning.text = String.Empty;
    }

    IEnumerator machineWarning()
    {
        keyCardWarning.text = machineTracker.machineAmount + " machines remaining";
        yield return new WaitForSeconds(2);
        keyCardWarning.text = String.Empty;
    }
}
