using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class Points : MonoBehaviour
{
    public float radius;
    public float ColorTime = 0.125f;
    float currentSaturation;
    public Volume volume;
    [SerializeField] private PointsManager point;
    private ItemCollected item;
    
    void Start() 
    {
        item = GetComponent<ItemCollected>();
    }

    void Update() 
    {
       if(((this.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).sqrMagnitude < radius) && Input.GetKeyDown("e"))
       {
           PickUp();
       }
       if (item.isCollected == true || item.isScene == false)
        {
            gameObject.SetActive(false); 
        } 
        else if (item.isCollected == false && item.isScene == true)
        {
            gameObject.SetActive(true);   
        }

    }

    void PickUp()
    {
        point.points ++;
        StartCoroutine(Lerp(33f)); 
        Debug.Log(point.points);
        item.isCollected = true;
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
