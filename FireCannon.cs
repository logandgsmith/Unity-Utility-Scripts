using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
