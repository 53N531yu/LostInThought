using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorItemPicked : MonoBehaviour
{
    public float radius;
    [SerializeField]
    private PointsManager point;

    void Start()
    {
        //point.points = 0;
    }
    void Update() 
    {
       if(((this.gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).sqrMagnitude < radius) && Input.GetKeyDown("e"))
       {
           if(point.important == true)
           {
               point.important = false;
           }
           else if(point.important == false)
           {
               point.important = true;
           }
       }
    }
}
