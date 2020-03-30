using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekOut : MonoBehaviour
{
    public GameObject target;

    public float speed = 0.5f;
    float step = 0;
    bool forward = true;

    // Update is called once per frame
    void Update()
    {
        if (step < 100.0f && forward)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            step++;
        }
        else
        {
            forward = false;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            step--;

            if (step == 0.0f)
                forward = true;
        }
    }
}
