using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGameObj : MonoBehaviour
{
    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            GetComponent<Rigidbody>().AddForce(0, 0, speed);
        if (Input.GetKeyDown(KeyCode.S))
            GetComponent<Rigidbody>().AddForce(0, 0, -speed);
        if (Input.GetKeyDown(KeyCode.E))
            GetComponent<Rigidbody>().AddForce(speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.W))
            GetComponent<Rigidbody>().AddForce(-speed, 0, 0);
    }
}
