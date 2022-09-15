using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private PieceSlot pieceSlot;
    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;

    public void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        pieceSlot.Placeable = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
        pieceSlot.Placeable = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
