using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnim : MonoBehaviour
{
    // Start is called before the first frame update

    public float seconds;
    public Sprite[] spriteSheet;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(explosions() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator explosions()
    {
        yield return new WaitForSeconds(seconds);
        audioSource.Play();
        for(int i=0; i<spriteSheet.Length; i++)
        {
            spriteRenderer.sprite = spriteSheet[i];
            yield return new WaitForSeconds(.15f);
        }
        StartCoroutine(explosions());
    }
}
