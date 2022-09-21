using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource[] A1aud;
    public AudioSource[] A2aud;
    public AudioSource currentMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Area1")
        {
            MusicLoop(A1aud);
        }
        else if (other.tag == "Area2")
        {
            MusicLoop(A2aud);
        }
    }

    public void MusicLoop(AudioSource[] Aaud)
    {
        int i = Random.Range(0, Aaud.Length);
        Aaud[i].Play();
    }
}
