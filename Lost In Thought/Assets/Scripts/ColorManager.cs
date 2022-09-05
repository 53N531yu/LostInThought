using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private PointsManager point;
    
    public float current;
    float currentSaturation;
    public float ColorTime = 0.125f;

    public Volume volume;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Area1")
        {
            point.desiredSaturation = point.desiredSaturation1;
            StartCoroutine(AreaLerp(33f, point._desiredSaturation1));
        }
        else if (other.tag == "Area2")
        {
            point.desiredSaturation = point.desiredSaturation2;
            StartCoroutine(AreaLerp(33f, point._desiredSaturation2));
        }
    }

    IEnumerator AreaLerp(float SatVal, float desiredSat)
    {
        float timeElapsed = 0;
        if(volume.profile.TryGet<ColorAdjustments>(out var ca))
        {
            currentSaturation = ca.saturation.value;
            point.desiredSaturation = desiredSat;
            while (timeElapsed < ColorTime)
            {
               ca.saturation.value = Mathf.Lerp(currentSaturation, point.desiredSaturation, timeElapsed / ColorTime);  
               timeElapsed += Time.deltaTime;        
            }   
            ca.saturation.value = point.desiredSaturation; 
        }

        yield return null;
    }
}
