﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    public GameObject cube;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayTheBox());
    }

    IEnumerator DelayTheBox()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        cube.SetActive(false);
    }
}
