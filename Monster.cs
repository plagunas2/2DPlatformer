using UnityEngine;

public class Monster : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 0.005f;
    public bool flip = true;
    public bool right = true;
    public float offset = 0f;
    float x;
    public GameObject player;
    public GameObject bullet;
    public float bulletSpeed = 1f;
    int count = 100;

    void Start()
    {
        x = transform.position.x;
        transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        count++;
        if (Vector3.Distance(player.transform.position, transform.position) < 3 && count>100)
        {
            count = 0;
            GameObject tmp = Instantiate(bullet, transform.position - Vector3.right, Quaternion.Euler(0, 0, 0));
            Rigidbody2D tmpRB = tmp.GetComponent<Rigidbody2D>();
            Destroy(tmp, 5f);
            tmpRB.AddForce(new Vector2(-5, 0) * bulletSpeed);
        }
        else
        {

            if (right == true)
            {
                transform.Translate(Vector2.right * speed);
            }
            else
            {
                transform.Translate(Vector2.left * speed);
            }

            if (transform.position.x > x + distance || transform.position.x < x - distance)
            {
                right = !right;
                if (flip == true)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1;
                    transform.localScale = localScale;
                }
            }
        }
    }
}
