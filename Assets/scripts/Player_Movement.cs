using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Parameters
    private float movementSpeed = 350f;
    private float jumpForce = 400f;
    private float airMovementMult = 0.5f;
    private float interactDistance = 5f;

    //store camera and player GameObjects
    private GameObject camera;
    private GameObject player;

    //store Highlight GameObject
    //used to highlight interactable voxels.
    private GameObject highlight;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        highlight = GameObject.FindGameObjectWithTag("Highlight");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = camera.transform.forward * movementSpeed * Time.fixedDeltaTime;
        Vector3 right = camera.transform.right * movementSpeed * Time.fixedDeltaTime;
        

        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        

        bool grounded = IsGrounded();

        //slow down movement while in the air
        if (!grounded)
        {
            forward *= airMovementMult;
            right *= airMovementMult;
        }

        //makes sure vertical velocity remains the same
        forward.y = right.y = rigidbody.velocity.y;

        if (Input.GetKey("up"))
        {

            rigidbody.velocity = forward;
        }

        if (Input.GetKey("down"))
        {
            rigidbody.velocity = -forward;
        }

        if (Input.GetKey("right"))
        {
            rigidbody.velocity = right;
        }

        if (Input.GetKey("left"))
        {
            rigidbody.velocity = -right;
        }

        if (grounded && Input.GetKeyUp("space"))
        {

            Rigidbody rigidBody = player.GetComponent<Rigidbody>();

            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance))
        {
            GameObject highlighted = hit.transform.gameObject;
            highlight.transform.position = highlighted.transform.position;
            highlight.transform.rotation = highlighted.transform.rotation;
        } else
        {
            highlight.transform.position = new Vector3(-10, -10, -10);
        }

    }

    private bool IsGrounded()
    {
        Vector3 pos = player.transform.position + new Vector3(0, -0.9f, 0);
        return Physics.Raycast(pos, -Vector3.up, 0.5f);
    }
}
