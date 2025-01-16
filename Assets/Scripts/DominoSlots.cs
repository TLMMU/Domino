//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using UnityEngine.U2D;
//using UnityEditorInternal.VersionControl;
//using UnityEngine.Events;
//using System;
//using UnityEngine.EventSystems;

//public class DominoSlots : MonoBehaviour
//{
//    private int DominoSpawnSlots = 6;//these are how many dominoes that will spawn within this slot
//    [SerializeField] GameObject DominoSpawnSlotPrefab;
//    [SerializeField] GameObject DominoDragPrefab;
//    [SerializeField] GameObject TopHalfPrefab;
//    [SerializeField] GameObject BtmHalfPrefab;
//    private GameObject slots;
//    private GameObject TopHalf;
//    private GameObject BtmHalf;
//    private GameObject spawn;

//    public int topValue;
//    public int bottomValue;
    
//    [SerializeField] Sprite[] TopHalfSprite;
//    [SerializeField] Sprite[] BtmHalfSprite;
//    private List<int> TopHalfValues = new List<int>();
//    private List<int> BtmHalfValues = new List<int>();
//    [SerializeField] GameObject[] TopHalfObjects;
//    [SerializeField] GameObject[] BtmHalfObjects;



//    public void SetSprite()
//    {
//        //loads our spritesheets in two separate arrays
//        TopHalfSprite = Resources.LoadAll<Sprite>("top_half");
//        BtmHalfSprite = Resources.LoadAll<Sprite>("btm_half");
//        //loads our gameobjects in two separate arrays
//        TopHalfObjects = GameObject.FindGameObjectsWithTag("TopHalf");
//        BtmHalfObjects = GameObject.FindGameObjectsWithTag("BtmHalf");

//        var tophalfobjsandvalues = TopHalfValues.Zip(TopHalfObjects, (val, obj) => new { Values = val, Objs = obj });//this iterates through both the prefab array and the integer list at the same time
//        int x = 0;
//        int xy = 0;
//        foreach (var numobj in tophalfobjsandvalues)
//        {
//            TopHalfObjects[x].GetComponent<SpriteRenderer>().sprite = TopHalfSprite[numobj.Values];
//            x++;
//        }
//        var btmhalfobjsandvalues = BtmHalfValues.Zip(BtmHalfObjects, (val, obj) => new { Values = val, Objs = obj });
//        foreach (var numobj in btmhalfobjsandvalues)
//        {
//            BtmHalfObjects[xy].GetComponent<SpriteRenderer>().sprite = BtmHalfSprite[numobj.Values];
//            xy++;
//        }
//    }
//    public void GenerateDomino()
//    {
//        for (int i = 0; i < DominoSpawnSlots; i++)
//        {
//            //Generate a random number between x and y for the top number     
//            topValue = UnityEngine.Random.Range(0, 6);
//            //Generate a random number between x and y for the bottom number
//            TopHalfValues.Add(topValue);
//            bottomValue = UnityEngine.Random.Range(0, 6);
//            BtmHalfValues.Add(bottomValue);
//        }
//        SetSprite();

//    }
//    void Start()
//    {
//        for (int i = 0; i < DominoSpawnSlots; i++)
//        {
//            slots = Instantiate(DominoSpawnSlotPrefab, transform) as GameObject;//this will spawn an instance of the dominoslot prefab within the domino group
//            slots.gameObject.name = "spawnslot" + i;
//            spawn = Instantiate(DominoDragPrefab) as GameObject;
//            spawn.transform.SetParent(slots.transform);
//            spawn.gameObject.name = "domino" + i;
//            TopHalf = Instantiate(TopHalfPrefab) as GameObject;
//            TopHalf.transform.SetParent(spawn.transform);
//            BtmHalf = Instantiate(BtmHalfPrefab) as GameObject;
//            BtmHalf.transform.SetParent(spawn.transform);
//        }
//        GenerateDomino();
//    }

//}