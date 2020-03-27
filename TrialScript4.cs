using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript4 : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            cube.SetActive(!cube.activeSelf);
        else if (Input.GetKeyDown(KeyCode.S))
            sphere.SetActive(!sphere.activeSelf);
            
    }
}
