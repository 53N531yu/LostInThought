using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceSlot : MonoBehaviour, IDropHandler
{
    public bool Placeable = true;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && gameObject.tag == eventData.pointerCurrentRaycast.gameObject.tag)
        {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Placeable = true;
        }
    }
}
