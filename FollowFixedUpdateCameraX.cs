using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFixedUpdateCameraX : MonoBehaviour
{
    public Transform target;
    public float offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);
    }
}
