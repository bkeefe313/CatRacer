using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraController : MonoBehaviour
{

    Camera cam;
    public GameObject subject;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // zoom in
        if (Input.GetKey(KeyCode.W))
        {
            cam.fieldOfView -= 1;
        }
        // zoom out
        if (Input.GetKey(KeyCode.S))
        {
            cam.fieldOfView += 1;
        }

        // look at subject
        if(subject != null)
        {
            transform.LookAt(subject.transform);
        }

        // follow subject
        if (subject != null)
        {
            transform.position = subject.transform.position + offset;
        }

        // rotate around subject
        if (Input.GetKey(KeyCode.A))
        {
            offset = Quaternion.AngleAxis(1, Vector3.up) * offset;
        }

        if (Input.GetKey(KeyCode.D))
        {
            offset = Quaternion.AngleAxis(-1, Vector3.up) * offset;
        }

    }
}
