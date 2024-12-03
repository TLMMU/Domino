using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DominoMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private Vector3 offset;// vector 3 variable needed for making sure the domino is aligned with the mouse position as it is being dragged around
    private float moveSpeedLimit = 1000; //this is speed limit set for when the domino is being dragged

    public bool isHovering; //these are the two states for our dominoes
    public bool isDragging;
    
    // these are the two events for our dominoes
    public UnityEvent<DominoMovement> BeginDragEvent;
    public UnityEvent<DominoMovement> EndDragEvent;

    private Vector3 originalPosition;

    DominoSlots DominoSpawnSlotPrefab;    
    void Start()
    {
        DominoSlots.dominosSpawned += SetStartPos;
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;//this vector2 variable is set to the mouse position minus the offset
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;//
            Vector2 velocity = direction * Mathf.Min(moveSpeedLimit, Vector2.Distance(transform.position, targetPosition) / Time.deltaTime);//
            transform.Translate(velocity * Time.deltaTime);//
        }
    }
    private void SetStartPos()
    {
        //originalPosition = DominoSpawnSlotPrefab.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //vector2 
        offset = mousePosition - (Vector2)transform.position;//
        isDragging = true;        
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);

        StartCoroutine(FrameWait()); //due to how grid layout works, a couroutine is needed in order 

        IEnumerator FrameWait()
        {
            yield return new WaitForEndOfFrame();            
            transform.localPosition = originalPosition;
            isDragging = false;
        }
    }
}
    