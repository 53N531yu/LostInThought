using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSample : MonoBehaviour
{
    public int radius;

    public GameObject Talk;
    public GameObject rhythmGame;
    public GameObject Mother;
    public GameObject Player;
    public ProdigyDialogue ProdDialogue;
    public PlayerMovement move;

    [SerializeField]
    private PointsManager point;

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        if((this.gameObject.transform.position - Player.transform.position).sqrMagnitude < radius && Input.GetKeyDown("e"))
        {
            move.enabled = false;
            if(gameObject.tag == "Prodigy" && point.points >= 1)
            {
                Talk.SetActive(true);
            }
            if(gameObject.tag == "Perfectionist")
            {
                rhythmGame.SetActive(true);
            }
            else
            {
                move.enabled = true;
            }
        }
    }
}
