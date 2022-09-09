using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private PointsManager point;
    
    public bool movedArea = false;
    float currentSaturation;
    public float ColorTime;
    public Volume volume;


    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Area1")
        {
            point.desiredSaturation1 = point.desiredSaturation;
        }
        else if (other.tag == "Area2")
        {
            point.desiredSaturation2 = point.desiredSaturation;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Area1")
        {
            StartCoroutine(AreaLerp(point.desiredSaturation1));
        }
        else if (other.tag == "Area2")
        {
            StartCoroutine(AreaLerp(point.desiredSaturation2));
        }
    }

    IEnumerator AreaLerp(float desiredSat)
    {
        float time = 0;
        if(volume.profile.TryGet<ColorAdjustments>(out var ca))
        {
            currentSaturation = ca.saturation.value;    
            point.desiredSaturation = desiredSat;
            while (time < ColorTime)
            {
               ca.saturation.value = Mathf.Lerp(currentSaturation, point.desiredSaturation, time / ColorTime);  
               time += Time.deltaTime;     
               yield return null;   
            }   
            ca.saturation.value = point.desiredSaturation; 
        }

        
    }
}
