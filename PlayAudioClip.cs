using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    public AudioClip myClip;
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(myClip);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.A))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(myClip);
        }
    }
}
