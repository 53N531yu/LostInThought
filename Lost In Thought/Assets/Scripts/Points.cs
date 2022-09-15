using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Points : MonoBehaviour
{
    public float radius;
    public float ColorTime = 0.125f;
    float currentSaturation;
    public Volume volume;
    [SerializeField] private PointsManager point;
    
    void Update() 
    {
       if(((this.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).sqrMagnitude < radius) && Input.GetKeyDown("e"))
       {
           PickUp();
       }
    }

    void PickUp()
    {
        Destroy(gameObject);
           point.points ++;
           
           StartCoroutine(Lerp(33f));
           
           Debug.Log(point.points);
    }

    IEnumerator Lerp(float SatVal)
    {
        float timeElapsed = 0;
        if(volume.profile.TryGet<ColorAdjustments>(out var ca))
        {
            currentSaturation = ca.saturation.value;
            point.desiredSaturation = ca.saturation.value + SatVal;
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
