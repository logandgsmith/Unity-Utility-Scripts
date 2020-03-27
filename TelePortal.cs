using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortal : MonoBehaviour
{
    public string LevelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag(other.gameObject.tag))
        {
            Application.LoadLevel(LevelToLoad);
        }
    }
}
