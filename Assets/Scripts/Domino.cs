using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Domino : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 offset;
   
    public bool isHovering; // these are the two states for our dominoes
    public bool isDragging;

    // these are the two events for our dominoes
    public UnityEvent<Domino> BeginDragEvent;
    public UnityEvent<Domino> EndDragEvent;
   
        void Start()
    {
       
    }

    
    void Update()
    {
        if (isDragging)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;//
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = mousePosition - (Vector2)transform.position;
        isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);
        isDragging = false;
    }
}
    
