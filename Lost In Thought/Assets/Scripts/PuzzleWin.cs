using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWin : MonoBehaviour
{
    public GameObject youWin;
    [SerializeField] private PieceSlot pieceSlot1;
    [SerializeField] private PieceSlot pieceSlot2;
    [SerializeField] private PieceSlot pieceSlot3;
    [SerializeField] private PieceSlot pieceSlot4;
    void Update()
    {
        if(pieceSlot1.Placeable && pieceSlot2.Placeable && pieceSlot3.Placeable && pieceSlot4.Placeable)
        {
            youWin.SetActive(true);
        }
    }
}
