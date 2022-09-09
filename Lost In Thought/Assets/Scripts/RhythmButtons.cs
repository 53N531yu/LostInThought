using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmButtons : MonoBehaviour
{
    public RawImage button;
    public KeyCode keyToPress;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            button.color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyUp(keyToPress))
        {
            button.color = new Color32(183, 183, 183, 255);
        }
    }
}
