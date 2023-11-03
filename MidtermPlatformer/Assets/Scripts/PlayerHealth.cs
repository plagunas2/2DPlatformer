using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

   // private HealthManager healthManager;

    public Image healthBar;
    public float healthAmount = 100f;

    private SpriteRenderer player;
    Color normal;

    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<SpriteRenderer>();
        normal = player.color;
    }

    // Update is called once per frame

    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            //healthManager.takeDamage(10f);
            takeDamage(10f);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "ElectricTrap")
        {
            takeDamage(20f);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Health")
        {
            heal(20f);
            Destroy(collision.gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        StartCoroutine(damageSprite());
    }

    public void heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
        StartCoroutine(healSprite());
    }

    IEnumerator damageSprite()
    {
        player.color = Color.red;
        yield return new WaitForSeconds(.25f);
        player.color = normal;
    }

    IEnumerator healSprite()
    {
        player.color = Color.green;
        yield return new WaitForSeconds(.25f);
        player.color = normal;
    }
}
