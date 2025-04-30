using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementoInventario : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       if(transform.childCount == 0){
        ColeccionableInventario coleccionable = eventData.pointerDrag.GetComponent<ColeccionableInventario>();
        coleccionable.parentAfterDrag = transform;
       }
    }
}
