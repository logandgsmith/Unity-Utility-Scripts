using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTiles : MonoBehaviour
{
    public GameObject nextTile;

    private void Update()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(5);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !nextTile.activeSelf)
        {
            nextTile.SetActive(true);
        }
    }
}
