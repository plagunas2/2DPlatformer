using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    /**
    public GameObject weapon1;
    public GameObject weapon2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
    }**/

    public Boolean knife;
    public Boolean gun;

   // public AudioSource knifeSound;
    //public AudioSource gunSound;

    public AudioClip knifeSound;
    public AudioClip gunSound;

    public AudioSource weaponSound;
    // Start is called before the first frame update
    void Start()
    {
        knife = false;
        gun = true;

        weaponSound = gameObject.GetComponent<AudioSource>(); //come back to this

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (knife == false)
            {
                weaponSound.clip = knifeSound; 
                weaponSound.Play();
                knife = true;
                gun = false;
            }
            else
            {
                weaponSound.clip = gunSound;
                weaponSound.Play();
                knife = false;
                gun = true;
            }
        }

    }

    public void switchQ() //switching weapon using Q
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (knife == false)
            {
                knife = true;
                gun = false;
            }
            else
            {
                knife = false;
                gun = true;
            }
        }
    }
}
