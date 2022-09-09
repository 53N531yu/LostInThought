using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHit : MonoBehaviour
{
    public bool canBePressed;
    public bool GoodBePressed;
    public bool PoorBePressed;
    public KeyCode keyToPress;
    public BeatScroller Accuracy;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                Accuracy.accuracy += 100;
                Debug.Log("Score: 100");
            }
            
            if (GoodBePressed)
            {
                gameObject.SetActive(false);
                Accuracy.accuracy += 75;
                Debug.Log("Score: 75");
            } 

            if (PoorBePressed)
            {
                gameObject.SetActive(false);
                Accuracy.accuracy += 50;
                Debug.Log("Score: 50");
            }
        }
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BeatLine")
        {
            canBePressed = true;
        }
        if(other.tag == "GoodBeatLine")
        {
            GoodBePressed = true;
        }
        if(other.tag == "PoorBeatLine")
        {
            PoorBePressed = true;
        }
        if(other.tag == "PoorBeatLine" && this.gameObject.tag == "LastNote")
        {
            Debug.Log("Accuracy: " + Accuracy.accuracy/4f + "%");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "BeatLine")
        {
            canBePressed = false;
        }
        if(other.tag == "GoodBeatLine")
        {
            GoodBePressed = false;
        }
        if(other.tag == "PoorBeatLine")
        {
            PoorBePressed = false;
        }
    }

}
