using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject PlayArea;

    public static UnityAction PlayTurn;
    public void ResetParent()
    {
        GameManager.GetComponent<GameManager>().multiplier = 0;
        var AreaSlotChildren = new List<Rigidbody2D>();
        
        foreach (Rigidbody2D child in PlayArea.GetComponentsInChildren<Rigidbody2D>())//rigidbody is used as we need to change the position of the domino
        {
            if (child.gameObject.tag == "Domino")                
            {
                AreaSlotChildren.Add(child);
                foreach (Rigidbody2D item in AreaSlotChildren)
                {
                    item.position = new Vector3(0, -500, 0); //position is used here for the triggerexit function as transform.position ignores physics and does not trigger collisions
                    item.transform.eulerAngles = new Vector3(0, 0, 0);
                    var script = item.gameObject.GetComponent<DominoMovement>();                    
                    script.rotated = false;
                    script.dragLocked = false; 
                    var reparent = item.GetComponent<DominoMovement>().parent;
                    item.transform.SetParent(reparent.transform);
                }
            }
        }
    }
    public void ResetAreaSlots()//resets the positions of the play area slots that the dominoes parent to
    {
        var AreaSlots = new List<Transform>();
        foreach (Transform child in PlayArea.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.tag == "PlayAreaSlots")
            {
                AreaSlots.Add(child);
                foreach (Transform item in AreaSlots)
                {
                    item.transform.localEulerAngles = new Vector3(0, 0, 0);
                    item.transform.position = new Vector3(0, 800, 0);

                }
            }
        }

    }
    public void PlayHand()
    {
        PlayTurn.Invoke();
    }
}


