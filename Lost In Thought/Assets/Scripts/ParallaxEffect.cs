using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Vector3 lastPos;
    public Transform cam;
    public float speedCoefficient;

    void Start()
    {
         lastPos= cam.position;
    }

    void Update()
    {
        transform.position -= (lastPos - cam.position) * speedCoefficient;
        lastPos = cam.position;
    }
}
