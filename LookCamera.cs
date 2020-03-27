using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public Transform m_Camera;

    private void Update()
    {
        transform.LookAt(new Vector3(m_Camera.position.x, transform.position.y, m_Camera.position.z));
    }
}
