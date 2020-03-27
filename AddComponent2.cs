using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cube_RED")
        {
            Debug.Log("Cube RED Hit the FLOOR");
            collision.gameObject.AddComponent<DestroyObject>();
        }
    }
}
