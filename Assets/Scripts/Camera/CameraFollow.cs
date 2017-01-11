using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

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
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        if (Input.GetKeyDown("d") || h > 0)
        {
            if (target.rotation != Quaternion.Euler(0, 90f, 0))
                offset.x = (transform.position - target.position).x + (12.17f * 2);
        }
        else if (Input.GetKeyDown("a") || h < 0)
        {
            if (target.rotation != Quaternion.Euler(0, -90f, 0))
                offset.x = (transform.position - target.position).x - (12.17f * 2);
        }

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

}
