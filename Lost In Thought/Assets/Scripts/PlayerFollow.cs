using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent ai;
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ai.destination = player.position;
    }
}
