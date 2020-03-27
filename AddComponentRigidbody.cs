using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentRigidbody : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            if(!collision.gameObject.GetComponent<Rigidbody>())
            {
                collision.gameObject.AddComponent<Rigidbody>();
                collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
                ScoreCount.gscore += 1;
            }

        }
    }
}
