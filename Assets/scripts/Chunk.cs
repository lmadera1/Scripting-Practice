using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    //store voxels in chunk
    public Voxel[,,] voxels;

    //parameters
    public Vector3 pos;
   
    private int chunkLength;
    private float blockLength = 1f;
    private int buildHeight;

    //Directions
    //Chunks are aligned with world rotation
    private Vector3 forward = new Vector3(1f, 0f, 0f);
    private Vector3 right = new Vector3(0f, 0f, 1f);

    private GameObject grass;

    public Chunk(Vector3 _pos, int _chunkLength = 16, int _buildHeight = 360)
    {
        pos = _pos;
        chunkLength = _chunkLength;
        buildHeight = _buildHeight;
        grass = GameObject.FindGameObjectWithTag("Grass");
        voxels = new Voxel[chunkLength, buildHeight, chunkLength];
        GenerateChunk();
    }

    private void GenerateChunk()
    {
        //start from corner of Chunk
        Vector3 start = pos - new Vector3(chunkLength / 2f, 0, chunkLength / 2f);
        //Create voxels
        for (int x = 0; x < chunkLength; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                Vector3 newPos = start + blockLength * (x * forward + z * right);
                GenerateColumn(newPos, x, z);
            }
        }

        //Activate visible voxels
        ActivateVisible();

    }

    private void ActivateVisible()
    {
        
        for (int x = 0; x < chunkLength; x++)
        {
            for (int z = 0; z < chunkLength; z++)
            {
                for (int y = 0; y < buildHeight; y++)
                {
                    Voxel voxel = voxels[x, y, z];

                    if (voxel.type == "air") continue;

                    
                    //check if surrounded
                    if (!IsSurrounded(x, y, z))
                    {
                        voxel.ShowFaces(new string[0]);
                        continue;
                    }
                    

                }
            }
        }
    }

    private bool IsSurrounded(int x, int y, int z)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    //don't surround yourself!
                    if (i == 0 && k == 0 && j == 0) continue;

                    //check if out of bounds
                    if (i + x >= chunkLength || i + x < 0) continue;
                    if (k + z >= chunkLength || k + z < 0) continue;
                    if (j + y >= buildHeight || j + y < 0) continue;

                    Voxel voxel = voxels[i + x, j + y, k + z];
                    if (voxel.type == "air") return false;

                }
            }
        }
        return true;
    }

    private void GenerateColumn(Vector3 start, int x, int z)
    {
        
        for (int y = 0; y < buildHeight; y++)
        {
            start.y = y;
            GameObject cube = GameObject.Instantiate(grass, start, Quaternion.identity);
            cube.SetActive(false);

            Voxel voxel = new Voxel(cube);
            //TODO: change later
            if (start.y <= 100)
            {
                voxel.type = "grass";
            }
            
            voxels[x, y, z] = voxel;
        }
    }



}
