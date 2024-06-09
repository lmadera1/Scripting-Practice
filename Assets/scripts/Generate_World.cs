using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_World : MonoBehaviour
{
    //parameters
    private int _worldLength = 1;
    private int _chunkLength = 16;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Generate world around player
        InitializeWorld(player.transform.position, _worldLength, _chunkLength);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeWorld(Vector3 pos, int worldLength, int chunkLength)
    {
        //assumes pos should be center of Generated world
        //World is generated as worldLength x worldLength x worldLength

        int max = worldLength / 2;
        int min = -worldLength / 2;


        for (int i = min; i <= max; i++)
        {
            for (int j = min; j <= max; j++)
            {
                Vector3 nextPos = pos + new Vector3(i, 0, j);
                Chunk chunk = new Chunk(nextPos, chunkLength);

            }
        }

    }
}
