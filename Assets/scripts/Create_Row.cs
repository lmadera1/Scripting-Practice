using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Row : MonoBehaviour
{
    //parameters
    Vector3 _pos = new Vector3(1, 1, 1);
    Vector3 _forward = new Vector3(1, 0, 0);
    //like minecraft
    int _num = 16;
    int _length = 1;

    // Start is called before the first frame update
    void Start()
    {
        createRow(_length, _num, _pos, _forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createRow(int length, int num, Vector3 pos, Vector3 forward)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //update cube position
            cube.transform.position = pos;
            //update cube orientation
            cube.transform.forward = forward;
            //set length of cube
            cube.transform.localScale = new Vector3(length, length, length);
            //update pos
            pos += forward * length / 2;

        }
    }

    
}
