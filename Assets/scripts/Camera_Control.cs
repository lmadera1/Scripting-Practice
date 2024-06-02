using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    float pitch = 0.0f;
    float yaw = 0.0f;
    float xSpeed = 3f;
    float ySpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += xSpeed * Input.GetAxisRaw("Mouse X");
        pitch -= ySpeed * Input.GetAxisRaw("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
