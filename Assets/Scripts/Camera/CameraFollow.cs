using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("d"))
        {
            if (target.rotation != Quaternion.Euler(0, 90f, 0))
                offset.x = (transform.position - target.position).x + (12.17f * 2);
        }
        else if (Input.GetKeyDown("a"))
        {
            if (target.rotation != Quaternion.Euler(0, -90f, 0))
                offset.x = (transform.position - target.position).x - (12.17f * 2);
        }

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

}
