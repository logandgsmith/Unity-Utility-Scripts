using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript2 : MonoBehaviour
{
    public GameObject cube;
    public Material matRed;
    public Material matTexture;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            cube.GetComponent<Renderer>().material = matRed;
        else if (Input.GetKeyDown(KeyCode.T))
            cube.GetComponent<Renderer>().material = matTexture;
    }
}
