using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_World : MonoBehaviour
{
    //parameters
    private int _worldLength = 3;
    private int _chunkLength = 16;
    private int buildHeight = 360;

    //store GameObject player for future reference
    private GameObject player;

    //store generated chunks for future reference
    private Dictionary<(int, int), Chunk> chunks;

    //store world origin
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        origin = player.transform.position;
        chunks = new Dictionary<(int, int), Chunk>();

        //Generate world around player
        InitializeWorld(origin, _worldLength, _chunkLength, buildHeight);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeWorld(Vector3 pos, int worldLength, int chunkLength, int buildHeight)
    {
        //check parameters
        if (worldLength < 1 || worldLength % 2 == 0)
        {
            //TODO: Throw error
        }

        if (chunkLength < 1)
        {
            //TODO: Throw error
        }

        //assumes pos should be center of Generated world
        //World is generated as worldLength x worldLength x worldLength

        int max = worldLength / 2;
        int min = -max;

        for (int x = min; x <= max; x++)
        {
            for (int z = min; z <= max; z++)
            {
                Vector3 nextPos = pos + new Vector3(x * chunkLength, 0, z * chunkLength);
                Chunk chunk = new Chunk(nextPos, chunkLength, buildHeight);

                //Integrate chunk voxels with neighboring chunks' voxels
                IntegrateChunk(ref chunk, x, z);


                //store chunks
                //Dictionary key is chunk pos relative to world origin
                chunks[(x, z)] = chunk;

            }
        }

    }

    void IntegrateChunk(ref Chunk chunk, int x, int z)
    {
        //check forward
        IntegrateForward(ref chunk, x, z);

        //check back
        IntegrateBack(ref chunk, x, z);

        //check left
        IntegrateLeft(ref chunk, x, z);

        //check right
        IntegrateRight(ref chunk, x, z);
    }

    void IntegrateForward(ref Chunk chunk, int x, int z)
    {
        (int, int) forwardKey = (x, z + 1);

        //No forward chunk created yet
        if (!chunks.ContainsKey(forwardKey)) return;

        Chunk forwardChunk = chunks[forwardKey];

        int voxelZ = _chunkLength - 1;
        int neighborZ = 0;

        for (int voxelY = 0; voxelY < buildHeight; voxelY++)
        {
            for (int voxelX = 0; voxelX < _chunkLength; voxelX++)
            {
                Voxel currVoxel = chunk.voxels[voxelX, voxelY, voxelZ];
                Voxel neighbor = forwardChunk.voxels[voxelX, voxelY, neighborZ];

                if (currVoxel.type != "air" && neighbor.type == "air")
                {
                    currVoxel.ShowFaces(new string[0]);
                }

                if (currVoxel.type == "air" && neighbor.type != "air")
                {
                    neighbor.ShowFaces(new string[0]);
                }
            }
        }
    }

    void IntegrateBack(ref Chunk chunk, int x, int z)
    {
        (int, int) backKey = (x, z - 1);

        //No forward chunk created yet
        if (!chunks.ContainsKey(backKey)) return;

        Chunk backChunk = chunks[backKey];

        int voxelZ = 0;
        int neighborZ = _chunkLength - 1;

        for (int voxelY = 0; voxelY < buildHeight; voxelY++)
        {
            for (int voxelX = 0; voxelX < _chunkLength; voxelX++)
            {
                Voxel currVoxel = chunk.voxels[voxelX, voxelY, voxelZ];
                Voxel neighbor = backChunk.voxels[voxelX, voxelY, neighborZ];

                if (currVoxel.type != "air" && neighbor.type == "air")
                {
                    currVoxel.ShowFaces(new string[0]);
                }

                if (currVoxel.type == "air" && neighbor.type != "air")
                {
                    neighbor.ShowFaces(new string[0]);
                }
            }
        }
    }

    void IntegrateLeft(ref Chunk chunk, int x, int z)
    {
        (int, int) leftKey = (x - 1, z);

        //No forward chunk created yet
        if (!chunks.ContainsKey(leftKey)) return;

        Chunk leftChunk = chunks[leftKey];

        int voxelX = 0;
        int neighborX = _chunkLength - 1;

        for (int voxelY = 0; voxelY < buildHeight; voxelY++)
        {
            for (int voxelZ = 0; voxelZ < _chunkLength; voxelZ++)
            {
                Voxel currVoxel = chunk.voxels[voxelX, voxelY, voxelZ];
                Voxel neighbor = leftChunk.voxels[neighborX, voxelY, voxelZ];

                if (currVoxel.type != "air" && neighbor.type == "air")
                {
                    currVoxel.ShowFaces(new string[0]);
                }

                if (currVoxel.type == "air" && neighbor.type != "air")
                {
                    neighbor.ShowFaces(new string[0]);
                }
            }
        }
    }

    void IntegrateRight(ref Chunk chunk, int x, int z)
    {
        (int, int) rightKey = (x + 1, z);

        //No forward chunk created yet
        if (!chunks.ContainsKey(rightKey)) return;

        Chunk rightChunk = chunks[rightKey];

        int voxelX = _chunkLength - 1;
        int neighborX = 0;

        for (int voxelY = 0; voxelY < buildHeight; voxelY++)
        {
            for (int voxelZ = 0; voxelZ < _chunkLength; voxelZ++)
            {
                Voxel currVoxel = chunk.voxels[voxelX, voxelY, voxelZ];
                Voxel neighbor = rightChunk.voxels[neighborX, voxelY, voxelZ];

                if (currVoxel.type != "air" && neighbor.type == "air")
                {
                    currVoxel.ShowFaces(new string[0]);
                }

                if (currVoxel.type == "air" && neighbor.type != "air")
                {
                    neighbor.ShowFaces(new string[0]);
                }
            }
        }
    }



}
