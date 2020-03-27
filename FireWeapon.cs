using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject weapon;
    float weaponImpulse = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Camera cam = Camera.main;
            GameObject theBullet = (GameObject)Instantiate(weapon, cam.transform.position + cam.transform.forward, cam.transform.rotation);
            theBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * weaponImpulse, ForceMode.Impulse);
        }
    }
}
