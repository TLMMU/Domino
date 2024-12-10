using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log(PlayAreaSlotCounter);
            if (PlayAreaSlotCounter == 0)
            {
                var slot0 = GameObject.Find("slot0");
                slot0.transform.position = Vector2.zero;
                col.transform.SetParent(slot0.transform);
                //if (hit.transform.gameObject.tag == "Domino")            
            }
            //else if (PlayAreaSlotCounter == 1)
            //{
            //    var slot1 = GameObject.Find("slot1");
            //    col.transform.SetParent(slot1.transform);
            //}
            //else if (PlayAreaSlotCounter == 2)
            //{
            //    var slot2 = GameObject.Find("slot2");
            //    col.transform.SetParent(slot2.transform);
            //}
            //else if (PlayAreaSlotCounter == 3)
            //{
            //    var slot3 = GameObject.Find("slot3");
            //    col.transform.SetParent(slot3.transform);
            //}
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Domino")
        {
            PlayAreaSlotCounter--;
            Debug.Log(PlayAreaSlotCounter);
        }
    }

    void Update()
    {
        
    }
}
