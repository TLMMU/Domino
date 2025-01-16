using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DominoMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private Vector3 originalPosition;//this is the position needed for when a domino is no longer being dragged
    private Vector3 offset;// vector 3 variable needed for making sure the domino is aligned with the mouse position as it is being dragged around
    private float moveSpeedLimit = 1000; //this is speed limit set for when the domino is being dragged

    //this is the dragging state for our dominoes
    public bool isDragging;

    //when set to true, it stops our domino from being dragged once it is in the play area
    public bool dragLocked;
    //this plays a key part in the domino rotation
    public bool rotated = false;

    // these are the two events for our dominoes
    public UnityEvent<DominoMovement> BeginDragEvent;
    public UnityEvent<DominoMovement> EndDragEvent;

    //this is for when the domino is dragged into the play area
    public Transform parentAfterDrag;
    //this is for our reset parent function on the button
    public GameObject parent;

    void Start()
    {
        parent = this.transform.parent.gameObject;
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            Vector2 velocity = direction * Mathf.Min(moveSpeedLimit, Vector2.Distance(transform.position, targetPosition) / Time.deltaTime);
            transform.Translate(velocity * Time.deltaTime);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragLocked == true)
        {
            return;
        }
        BeginDragEvent.Invoke(this);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = mousePosition - (Vector2)transform.position;
        isDragging = true;
        parentAfterDrag = transform.parent;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);
        StartCoroutine(FrameWait());//due to how grid layout is calculated, a coroutine is needed in order to update the position of the domino
        IEnumerator FrameWait()
        {
            yield return new WaitForEndOfFrame();
            transform.localPosition = originalPosition;//sets the domino's position back to 0, 0, 0
            isDragging = false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    { 
        if (this.transform.parent.tag == "PlayAreaSlots")//this is to make sure that the function is only called when the domino is parented to a play area slot
        {
            if (rotated == false)
            {
                if (this.transform.localEulerAngles.z == 0)
                {         
                        this.transform.localEulerAngles = new Vector3(0, 0, -180);
                        this.rotated = true;   
                }
            }
            else if (rotated == true)
            {
                if (this.transform.localEulerAngles.z == 180)
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    this.rotated = false;
                }
            }
        }
    }
}
                

            
            

        
  
    
