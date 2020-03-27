using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public GameObject cube;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            cube.GetComponent<Renderer>().material.color = Color.red;
    }
}
