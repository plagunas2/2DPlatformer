using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
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
    }
}
