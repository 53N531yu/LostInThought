using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class PointsManager : ScriptableObject
{
    [SerializeField] private int _points;
    [SerializeField] private bool _important;

    public float desiredSaturation = -100;
    public float desiredSaturation1 = -100;
    public float desiredSaturation2 = -100;

    public int points
    {
        get { return _points; }
        set { _points = value; }
    }

    public bool important
    {
        get { return _important; }
        set { _important = value; }
    }

    public float _desiredSaturation
    {
        get { return desiredSaturation; }
        set { desiredSaturation = value; }
    }

    public float _desiredSaturation1
    {
        get { return desiredSaturation1; }
        set { desiredSaturation1 = value; }
    }

    public float _desiredSaturation2
    {
        get { return desiredSaturation2; }
        set { desiredSaturation2 = value; }
    }
}
