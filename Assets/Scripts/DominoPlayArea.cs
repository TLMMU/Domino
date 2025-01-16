using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DominoPlayArea : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject GameManager;
    public int PlayAreaSlotCounter = -1;//this is set to -1 as we want our switch function to work correctly

    public static UnityAction MultiChange;

    public GameObject EmptySlotPrefab;
    public GameObject slots;
    public GameObject[] EmptyPlayAreaSlots;
    void Start()//these are the slots that our dominoes will parent to when they are dragged into the play area
    {
        for (int i = 0; i < 6; i++)
        {
            slots = Instantiate(EmptySlotPrefab, transform) as GameObject;
            slots.gameObject.name = "playareaslot" + i;            
        }
    }
    public void OnDrop(PointerEventData data)//this handles the "dynamic" aspect of our play area
    {
        GameObject DominoDropped = data.pointerDrag;
        DominoMovement Domino = DominoDropped.GetComponent<DominoMovement>();

        EmptyPlayAreaSlots = GameObject.FindGameObjectsWithTag("PlayAreaSlots");         

        switch (PlayAreaSlotCounter)//each case creates a new shape with each domino added
        {
            case 0://no shape
                Domino.transform.SetParent(EmptyPlayAreaSlots[0].transform);
                EmptyPlayAreaSlots[0].transform.position = new Vector2(0, 50);              
                Domino.dragLocked = true;
                break;
            case 1://side by side                
                EmptyPlayAreaSlots[0].transform.position = new Vector2(-85, 60);
                //the rotation is applied to the slot rather than domino. this allows the domino itself to be rotated through the onpointerclick function.
                //the downside however, it messes up how the dragevents work and was unable to find a solution in time so I had to compromise by disabling the dragevent and created a button with a function that resets the positions and parents of all dominoes.
                //this also meant I was unable to create a system where the dominoes swap positions which makes the gameplay less than ideal
                EmptyPlayAreaSlots[0].transform.localEulerAngles = new Vector3(0, 0, 90);        
                Domino.transform.SetParent(EmptyPlayAreaSlots[1].transform);
                EmptyPlayAreaSlots[1].transform.position = new Vector2(85, 60);
                EmptyPlayAreaSlots[1].transform.localEulerAngles = new Vector3(0, 0, 90);
                GameManager.GetComponent<GameManager>().multiplier+=2;
                Domino.dragLocked = true;
                break;
            case 2://upside down triangle
                EmptyPlayAreaSlots[0].transform.localEulerAngles = new Vector3(0, 0, -45);
                EmptyPlayAreaSlots[1].transform.position = new Vector2(0, -50);
                Domino.transform.SetParent(EmptyPlayAreaSlots[2].transform);
                EmptyPlayAreaSlots[1].transform.localEulerAngles = new Vector3(0, 0, 90);
                EmptyPlayAreaSlots[2].transform.position = new Vector2(85, 60);
                EmptyPlayAreaSlots[2].transform.localEulerAngles = new Vector3(0, 0, 45);
                GameManager.GetComponent<GameManager>().multiplier++;
                Domino.dragLocked = true;
                break;
            case 3://square  
                EmptyPlayAreaSlots[0].transform.localEulerAngles = new Vector3(0, 0, 0);
                EmptyPlayAreaSlots[1].transform.position = new Vector2(0, -50);
                EmptyPlayAreaSlots[2].transform.position = new Vector2(0, 175);                
                EmptyPlayAreaSlots[2].transform.localEulerAngles = new Vector3(0, 0, 90);
                Domino.transform.SetParent(EmptyPlayAreaSlots[3].transform);
                EmptyPlayAreaSlots[3].transform.position = new Vector2(85, 60);
                GameManager.GetComponent<GameManager>().multiplier++;
                Domino.dragLocked = true;
                break;
            case 4://pentagon
                EmptyPlayAreaSlots[0].transform.position = new Vector2(-110, 50);
                EmptyPlayAreaSlots[0].transform.localEulerAngles = new Vector3(0, 0, 20);
                EmptyPlayAreaSlots[2].transform.position = new Vector2(-85, 195);
                EmptyPlayAreaSlots[2].transform.localEulerAngles = new Vector3(0, 0, -45);                
                EmptyPlayAreaSlots[3].transform.position = new Vector2(85, 195);
                EmptyPlayAreaSlots[3].transform.localEulerAngles = new Vector3(0, 0, 45);                
                Domino.transform.SetParent(EmptyPlayAreaSlots[4].transform);
                EmptyPlayAreaSlots[4].transform.position = new Vector2(110, 50);
                EmptyPlayAreaSlots[4].transform.localEulerAngles = new Vector3(0, 0, -20);
                GameManager.GetComponent<GameManager>().multiplier++;
                Domino.dragLocked = true;
                break;
            case 5://hexagon
                EmptyPlayAreaSlots[0].transform.position = new Vector2(-120, 50);
                EmptyPlayAreaSlots[0].transform.localEulerAngles = new Vector3(0, 0, 40);  
                EmptyPlayAreaSlots[2].transform.position = new Vector2(-120, 200);
                EmptyPlayAreaSlots[2].transform.localEulerAngles = new Vector3(0, 0, -40);
                EmptyPlayAreaSlots[3].transform.position = new Vector2(0, 300);
                EmptyPlayAreaSlots[3].transform.localEulerAngles = new Vector3(0, 0, 90);
                EmptyPlayAreaSlots[4].transform.position = new Vector2(120, 200);
                EmptyPlayAreaSlots[4].transform.localEulerAngles = new Vector3(0, 0, 40);
                Domino.transform.SetParent(EmptyPlayAreaSlots[5].transform);
                EmptyPlayAreaSlots[5].transform.position = new Vector2(120, 50);
                EmptyPlayAreaSlots[5].transform.localEulerAngles = new Vector3(0, 0, -40);
                GameManager.GetComponent<GameManager>().multiplier+=2;
                Domino.dragLocked = true;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        PlayAreaSlotCounter++;  
    }
    void OnTriggerExit2D(Collider2D col)
    {
        PlayAreaSlotCounter--;
    }
    public void ClearSlots()
    {
        Array.Clear(EmptyPlayAreaSlots, 0, EmptyPlayAreaSlots.Length);
    }
    void Awake() 
    {
        Buttons.PlayTurn += ClearSlots;
    }
}