using UnityEngine;

public class Horizontal2D : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 0.005f;
    public bool flip = true;
    public bool right = true;
    public float offset = 0f;
    float x;


    void Start()
    {
        x = transform.position.x;
        transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
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
