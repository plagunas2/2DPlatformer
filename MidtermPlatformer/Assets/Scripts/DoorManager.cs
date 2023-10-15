using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update



    public Sprite[] sprites;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        
        this.gameObject.GetComponent<Collider2D>().enabled = true; //collider enabled at start of level (door closed)
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.sprite == sprites[sprites.Length - 1])
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false; //collider disabled when door open -> proceed to next level
        } 
    }

    public IEnumerator OpenDoor()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprite.sprite = sprites[i];
            yield return new WaitForSeconds(.14f);
        }
    }
}

