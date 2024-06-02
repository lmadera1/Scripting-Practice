using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        movementSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = camera.transform.forward * movementSpeed;
        forward.y = 0;
        Vector3 right = camera.transform.right * movementSpeed;
        right.y = 0;
        if (Input.GetKey("up"))
        {
            gameObject.transform.Translate(forward);
        }

        if (Input.GetKey("down"))
        {
            gameObject.transform.Translate(-forward);
        }

        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(right);
        }

        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-right);
        }
    }
}
