using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PointsManager : ScriptableObject
{
    [SerializeField]
    private int _points;

    public int points
    {
        get { return _points; }
        set { _points = value; }
    }
}
