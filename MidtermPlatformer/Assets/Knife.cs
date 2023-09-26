using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Translate(0.5f, 0, 0);
            Invoke("EndAttack", 0.5f);
        }
    } 
    
    void EndAttack()
    {
        transform.Translate(-0.5f, 0, 0);
    }
}
