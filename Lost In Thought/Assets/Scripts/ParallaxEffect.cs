using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Vector3 lastPos;
    public Transform camera;
    public float speedCoefficient;

    void Start()
    {
         lastPos= camera.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (lastPos - camera.position) * speedCoefficient;
        lastPos = camera.position;
    }
}
