﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls2D : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, speed, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-speed, 0, 0);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -speed, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(speed, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(cannonball, transform.position, transform.rotation);    



    }
}
