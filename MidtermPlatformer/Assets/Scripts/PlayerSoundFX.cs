using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFX : MonoBehaviour
{
    private SwitchWeapons weapon;
    public AudioSource weaponSound;
    public AudioClip gunShot;
    // Start is called before the first frame update
    void Start()
    {
        //weaponSound = this.gameObject.GetComponent<AudioSource>();
        weapon = GetComponent<SwitchWeapons>();
        weaponSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && weapon.gun == true )
        {
            weaponSound.clip = gunShot;
            weaponSound.Play();
        }
    }
}
