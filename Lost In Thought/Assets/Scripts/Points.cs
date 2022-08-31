using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
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
           Destroy(gameObject);
           point.points ++;
           Debug.Log(point.points);
       }
    }
}
