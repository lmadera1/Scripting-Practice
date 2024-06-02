using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            gameObject.transform.Translate(gameObject.transform.forward * movementSpeed);
        }

        if (Input.GetKey("down"))
        {
            gameObject.transform.Translate(-1 * gameObject.transform.forward * movementSpeed);
        }

        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(gameObject.transform.right * movementSpeed);
        }

        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-1 * gameObject.transform.right * movementSpeed);
        }
    }
}
