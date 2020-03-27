using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistObj : MonoBehaviour
{
    GameObject plyr;

    // Start is called before the first frame update
    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(plyr.transform.position, gameObject.transform.position);

        Light myLight = GameObject.Find("Light").GetComponent<Light>();

        Debug.Log(dist);

        if(dist <= 5.0f)
        {
            myLight.intensity = 15.0f;
        }
        else
        {
            myLight.intensity = 2f;
        }
    }
}
