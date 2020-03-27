using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargets : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
            ScoreCount.gscore += 1;
        }

    }
}
