using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            Debug.Log("PLAYER hit ME");
    }
}
