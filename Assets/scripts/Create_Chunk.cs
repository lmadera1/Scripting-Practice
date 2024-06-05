using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//hard coded to create chunks, aligned with world axes, of size 16x16x16
public class Create_Chunk : MonoBehaviour
{
    Vector3 start = new Vector3(20, 1, 20);
    Vector3 forward = new Vector3(1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    Vector3 right = new Vector3(0, 0, 1);
    int chunkLength = 16;
    int blockLength = 1;

    // Start is called before the first frame update
    void Start()
    {
        createChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createChunk()
    {
        for (int i = 0; i < chunkLength; i++)
        {
            createLayer(start);
            //move start up y axis
            start += up * blockLength / 2;
        }
    }

    void createLayer(Vector3 start)
    {
        for (int i = 0; i < chunkLength; i++)
        {
            createRow(start);
            start += right * blockLength / 2;
        }
    }

    void createRow(Vector3 start)
    {
        for (int i = 0; i < chunkLength; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //update cube position
            cube.transform.position = start;
            //update cube orientation
            cube.transform.forward = forward;
            //set length of cube
            cube.transform.localScale = new Vector3(blockLength, blockLength, blockLength);
            //update pos
            start += forward * blockLength / 2;

        }
    }
}