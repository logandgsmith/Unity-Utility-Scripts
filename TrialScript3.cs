using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        string hit = "";

        if (collision.gameObject.name == "Cube")
            hit = "CUBE";
        else if (collision.gameObject.name == "Sphere")
            hit = "SPHERE";
        else if (collision.gameObject.name == "Cylinder")
            hit = "CYLINDER";
        else
            return;

        Debug.Log(hit + " got HIT");
    }
}
