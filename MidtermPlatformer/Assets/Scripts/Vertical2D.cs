using UnityEngine;

public class Vertical2D : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 0.005f;
    public float offset = 0f;
    float y;
    bool up = true;

    void Start()
    {
        y = transform.position.y;
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
    }

    void FixedUpdate()
    {
        if (up == true)
        {
            transform.Translate(Vector2.up * speed);
        }
        else
        {
            transform.Translate(Vector2.down * speed);
        }

        if (transform.position.y > y + distance || transform.position.y < y - distance)
        {
            up = !up;
        }
    }
}
