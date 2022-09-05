using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProdigyDialogue : MonoBehaviour
{
    public GameObject Talk;
    public GameObject Mother;
    public GameObject DialogueOption;
    public PlayerMovement move;
    public Button theSky;
    [SerializeField]
    private PointsManager point;

    void Update()
    {
        if (point.important == true)
        {
            theSky.interactable = true;
        }
        else
        {
            theSky.interactable = false;
        }
    }

    public void Next()
    {
        DialogueOption.SetActive(true);
    }

    public void Proceed()
    {
        move.enabled = true;
        StartCoroutine(False());
    }

    IEnumerator False()
    {
        yield return new WaitForSecondsRealtime(3);
    }
}
