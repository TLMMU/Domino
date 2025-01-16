using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEditorInternal.VersionControl;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;

public class DominoSpawnGrid : MonoBehaviour
{
    private int DominoSpawnSlots = 6;
    [SerializeField] GameObject DominoSpawnSlotPrefab;
    [SerializeField] GameObject DominoDragPrefab;
    [SerializeField] GameObject TopHalfPrefab;
    [SerializeField] GameObject BtmHalfPrefab;
    private GameObject slots;
    private GameObject spawn;
    private GameObject TopHalf;
    private GameObject BtmHalf;   

    public int topValue;
    public int btmValue;

    [SerializeField] Sprite[] TopHalfSprite;
    [SerializeField] Sprite[] BtmHalfSprite;

    public Dictionary<GameObject, int> TopHalfDict = new Dictionary<GameObject, int> ();
    public Dictionary<GameObject, int> BtmHalfDict = new Dictionary<GameObject, int> ();

    public void SetSprite()//in the now unused dominoslots script, i had coded a more complicated way of adding sprites to each gameobject
    {
        //loads our spritesheets in two separate arrays
        TopHalfSprite = Resources.LoadAll<Sprite>("top_half");
        BtmHalfSprite = Resources.LoadAll<Sprite>("btm_half");
        
        foreach(var item in TopHalfDict)
        {   
            item.Key.GetComponent<SpriteRenderer>().sprite = TopHalfSprite[item.Value];
            item.Key.GetComponent<DominoValue>().RNGNumber = item.Value; //we need to give each domino gameobject the value so total values can be calculated 
            
        }
        foreach (var item in BtmHalfDict)
        {
            item.Key.GetComponent<SpriteRenderer>().sprite = BtmHalfSprite[item.Value];
            item.Key.GetComponent<DominoValue>().RNGNumber = item.Value;
        }
    }
    public void Clearup()
    {
        TopHalfDict.Clear();
        BtmHalfDict.Clear();
        Destroy(slots);
        Destroy(spawn);
        GenerateDomino();
    }
    void Awake()
    {
        Buttons.PlayTurn += Clearup;
    }
    public void GenerateDomino()//this function creates all the instances of the domino gameobject. This was originally under void start but I need to be able call this function again to spawn in new dominoes for each new turn
    {
        for (int i = 0; i < DominoSpawnSlots; i++)
        {
            slots = Instantiate(DominoSpawnSlotPrefab, transform) as GameObject;
            slots.gameObject.name = "spawnslot" + i;
            spawn = Instantiate(DominoDragPrefab) as GameObject;
            spawn.transform.SetParent(slots.transform);
            spawn.gameObject.name = "domino" + i;
            TopHalf = Instantiate(TopHalfPrefab) as GameObject;
            topValue = UnityEngine.Random.Range(0, 7);            
            TopHalfDict.Add(TopHalf, topValue);
            TopHalf.transform.SetParent(spawn.transform);            
            BtmHalf = Instantiate(BtmHalfPrefab) as GameObject;
            btmValue = UnityEngine.Random.Range(0, 7);
            BtmHalfDict.Add(BtmHalf, btmValue);
            BtmHalf.transform.SetParent(spawn.transform);
        }
        SetSprite();
    }

    void Start()
    {
        GenerateDomino();

    }

}

