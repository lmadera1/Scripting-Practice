using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    private GameObject[,,] voxels;

    public Vector3 pos;

    private float chunkLength;
    private float blockLength = 1f;
    private int buildHeight = 360;

    private Vector3 forward = new Vector3(1f, 0f, 0f);
    private Vector3 right = new Vector3(0f, 0f, 1f);

    private GameObject grass;

    public Chunk(Vector3 _pos, float _chunkLength)
    {
        pos = _pos;
        chunkLength = _chunkLength;
        grass = GameObject.FindGameObjectWithTag("Grass");
        GenerateChunk();
    }

    private void GenerateChunk()
    {
        //start from corner of Chunk
        Vector3 start = pos - new Vector3(chunkLength / 2f, 0, chunkLength / 2f);

        for (int x = 0; x < chunkLength; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                Vector3 newPos = start + blockLength * (x * forward + z * right);
                GenerateColumn(newPos);
            }
        }
    }

    private void GenerateColumn(Vector3 start)
    {
        start.y = 0;
        for (int y = 0; y < buildHeight; y++)
        {
            GameObject cube = GameObject.Instantiate(grass, start, Quaternion.identity);
            //TODO: change later
            if (start.y > 10)
            {
                cube.SetActive(false);
            }
            //TODO: store voxel
            //voxels[start.x, start.y, start.z] = cube;
            start.y++;
        }
    }



}
