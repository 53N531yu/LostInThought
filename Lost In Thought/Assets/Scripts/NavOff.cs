using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavOff : MonoBehaviour
{
    private NavMeshAgent play;

    void Start() 
    {
        play = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NavMeshOff")
        {
            play.enabled = false;
        }
    }

}
