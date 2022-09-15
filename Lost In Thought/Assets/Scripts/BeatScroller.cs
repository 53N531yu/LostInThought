using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public RectTransform rectTransform;
    public AudioSource music;
    public float accuracy;
    public int LongCounter = 0;

    void Start()
    {
        music = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            Scroll();
        }
    }

    void FixedUpdate() 
    {
        if (hasStarted)
        {
            if (!music.isPlaying)
            {
                music.Play();           
            }
        }
    }

    void Scroll()
    {
        Vector2 position = rectTransform.anchoredPosition;
        position.y -= beatTempo * Time.deltaTime;
        transform.localPosition = position;
    }
}
