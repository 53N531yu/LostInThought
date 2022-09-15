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
                LongNoteCon(100);
                ShortNoteCon(100);
            }
            
            if (GoodBePressed)
            {
                LongNoteCon(75);
                ShortNoteCon(75);
            } 

            if (PoorBePressed)
            {
                LongNoteCon(50);
                ShortNoteCon(50);
            }
        }
        if (Input.GetKeyUp(keyToPress))
        {
            if (gameObject.tag == "LongNote" && Accuracy.LongCounter == 1)
            {
                gameObject.GetComponent<NoteHit>().enabled = false;
                Accuracy.LongCounter = 0;
            }

            if (canBePressed && Accuracy.LongCounter == 2)
            {
                LongNoteCon(100);
                Accuracy.LongCounter = 0;
                DisableScript();
            }
            
            if (GoodBePressed && Accuracy.LongCounter == 2)
            {
                LongNoteCon(75);
                Accuracy.LongCounter = 0;
                DisableScript();
            } 

            if (PoorBePressed && Accuracy.LongCounter == 2)
            {
                LongNoteCon(50);
                Accuracy.LongCounter = 0;
                DisableScript();
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
        if((other.tag == "MissBeatLine" && gameObject.tag != "LongNote"))
        {
            gameObject.SetActive(false);
            Debug.Log("Score: 0");
        }
        if((other.tag == "LongMissLine" && gameObject.tag == "LongNote"))
        {
            gameObject.SetActive(false);
            Debug.Log("Score: 0");
        }
        if(other.tag == "LongNoteLine" && gameObject.tag == "LongNote")
        {
            Accuracy.LongCounter ++;
        }
        if(other.tag == "PoorBeatLine" && this.gameObject.tag == "LastNote")
        {
            Debug.Log("Accuracy: " + Accuracy.accuracy/6f + "%");
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

    public void LongNoteCon(float acc)
    {
        if(gameObject.tag == "LongNote")
        {
            Accuracy.accuracy += acc;
            Debug.Log("Score: " + acc);
        }
    }

    public void ShortNoteCon(float accu)
    {
        if (gameObject.tag != "LongNote")
        {
            gameObject.SetActive(false);
            Accuracy.accuracy += accu;
            Debug.Log("Score: " + accu);
        }
    }

    public void DisableScript()
    {
        gameObject.GetComponent<NoteHit>().enabled = false;
    }
}
