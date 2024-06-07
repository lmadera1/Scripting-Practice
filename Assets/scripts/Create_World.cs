using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_World : MonoBehaviour
{
    //parameters
    private int _worldLength = 10;
    private int _chunkLength = 5;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Generate world around player
        InitializeWorld(player.transform.position, _worldLength, _chunkLength) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeWorld(Vector3 pos, int worldLength, int chunkLength)
    {
        //assumes pos should be center of Generated world
        //World is generated as worldLength x worldLength x worldLength

        //offset pos to begin at corner of each chunk
        pos -= new Vector3(chunkLength / 2f, chunkLength / 2f, chunkLength / 2f);

        int max = worldLength / 2;
        int min = -worldLength / 2;

        
        for (int i = min; i <= max; i++)
        {
            for (int j = min; j <= max; j++)
            {
                for (int k = min; k <= max; k++)
                {
                    Vector3 nextPos = pos + new Vector3(i, j, k);
                    GenerateChunk(nextPos, chunkLength);
                }
            }
        }
        
    }

    //TODO move to seperate file
    //hard coded parameters for GenerateChunk()
    private Vector3 forward = new Vector3(1f, 0f, 0f);
    private Vector3 up = new Vector3(0f, 1f, 0f);
    private Vector3 right = new Vector3(0f, 0f, 1f);
    private float blockLength = 1f;
    void GenerateChunk(Vector3 start, int chunkLength)
    {
        for (int i = 0; i < chunkLength; i++)
        {
            createLayer(start, chunkLength);
            //move start up y axis
            start += up * blockLength;
        }
    }

    //TODO: move to another file
    void createLayer(Vector3 start, int chunkLength)
    {
        for (int i = 0; i < chunkLength; i++)
        {
            createRow(start, chunkLength);
            start += right * blockLength;
        }
    }

    //TODO: move to another file
    void createRow(Vector3 start, int chunkLength)
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

            //TODO: Replace later
            //deactivate if above a certain height
            if (start.y > 8)
            {
                cube.SetActive(false);
            }
            //update pos
            start += forward * blockLength;

        }
    }
}
