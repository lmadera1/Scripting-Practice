using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Blocks : MonoBehaviour
{
    private GameObject cube;
    private GameObject camera;
    private float distance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(3, 1, 3);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = camera.transform.position + camera.transform.forward * distance;
            cube.transform.position = newPos;
        }
    }
}
