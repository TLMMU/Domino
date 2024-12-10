using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DominoPlayArea : MonoBehaviour
{    
    private int PlayAreaSlotCounter = -1;
    
    [SerializeField] public GameObject EmptySlotPrefab;
    
    private GameObject AreaSlots;    
    void Start()
    {        
        for (int i = 0; i < 6; i++)
        {
            AreaSlots = Instantiate(EmptySlotPrefab, transform) as GameObject;
            AreaSlots.gameObject.name = "slot" + i;
        }        
    }
    void OnTriggerEnter2D(Collider2D col)//spawn instance of empty gameobj, if player drags into play area
    {
        if (col.gameObject.tag == "Domino")
        {
            PlayAreaSlotCounter++;        
                                  
            switch (PlayAreaSlotCounter)
            {
                case 0:
                    var slot0 = GameObject.Find("slot0");
                    slot0.transform.position = Vector2.zero;
                    col.transform.SetParent(slot0.transform);
                    break;
                case 1:
                    var slot1 = GameObject.Find("slot1");
                    col.transform.SetParent(slot1.transform);
                    break;
                case 2:
                    var slot2 = GameObject.Find("slot2");
                    col.transform.SetParent(slot2.transform);
                    break;
                case 3:
                    var slot3 = GameObject.Find("slot3");
                    col.transform.SetParent(slot3.transform);
                    break;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Domino")
        {
            PlayAreaSlotCounter--;

            EndDragEvent.Invoke(this);
            var reparent = col.GetComponent<DominoMovement>().parent;
            col.transform.SetParent(reparent.transform);
        }
    }

    void Update()
    {
        
    }
}
