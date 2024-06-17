using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel
{
    public string type;
    public GameObject cube;
    public Voxel(GameObject _cube = null, string _type = "air")
    {
        cube = _cube;
        type = _type;
    }

    public void ShowFaces(string[] faces)
    {
        cube.SetActive(true);
    }

    public void HideFaces()
    {
        cube.SetActive(false);
    }

    /*
    public void ShowFaces(string[] faces)
    {
        foreach(string face in faces)
        {
            ShowFace(face);
        }

        //TODO: update GameObject mesh
    }

    private void ShowFace(string face)
    {
        switch(face)
        {
            case "forward":
                break;
            case "back":
                break;
            case "top":
                break;
            case "bottom":
                break;
            case "left":
                break;
            case "right":
                break;
        }
    }

    */
}
