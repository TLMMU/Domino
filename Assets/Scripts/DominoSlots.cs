using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEditorInternal.VersionControl;
using UnityEngine.Events;
using System;

public class DominoSlots : MonoBehaviour
{
    [SerializeField] int DominoSpawnSlots = 6;//these are how many dominoes that will spawn within this slot
    [SerializeField] private GameObject DominoSpawnSlotPrefab;
    [SerializeField] public GameObject DominoDragPrefab;
    [SerializeField] public GameObject TopHalfPrefab;
    [SerializeField] public GameObject BtmHalfPrefab;
    private GameObject slots;
    private GameObject TopHalf;
    private GameObject BtmHalf;
    private GameObject spawn;

    public static UnityAction dominosSpawned;

    public int topValue;
    public int bottomValue;
    public int totalValue;
    [SerializeField] public Sprite[] TopHalfSprite;
    [SerializeField] public Sprite[] BtmHalfSprite;
    [SerializeField] private List<int> TopHalfValues = new List<int>();
    [SerializeField] private List<int> BtmHalfValues = new List<int>();
    [SerializeField] GameObject[] TopHalfObjects;
    [SerializeField] GameObject[] BtmHalfObjects;


    public void SetSprite(int topValue, int bottomValue)
    {        
        //loads our spritesheets in two separate arrays
        TopHalfSprite = Resources.LoadAll<Sprite>("top_half");
        BtmHalfSprite = Resources.LoadAll<Sprite>("btm_half");
        //loads our gameobjects in two separate arrays
        TopHalfObjects = GameObject.FindGameObjectsWithTag("TopHalf");
        BtmHalfObjects = GameObject.FindGameObjectsWithTag("BtmHalf");

        //int[] ValuesArray = TopHalfValues.ToArray();

        var tophalfobjsandvalues = TopHalfValues.Zip(TopHalfObjects, (val, obj) => new {Values = val, Objs = obj});
        int x = 0;
        int xy = 0;
        foreach (var numobj in tophalfobjsandvalues)
        {
            //TopHalf.GetComponent<SpriteRenderer>().sprite = TopHalfSprite[numobj.Values];
            TopHalfObjects[x].GetComponent<SpriteRenderer>().sprite = TopHalfSprite[numobj.Values];
            Debug.Log(numobj.Values);
            x++;
        }
        var btmhalfobjsandvalues = BtmHalfValues.Zip(BtmHalfObjects, (val, obj) => new { Values = val, Objs = obj });
        foreach (var numobj in btmhalfobjsandvalues)
        {
            BtmHalfObjects[xy].GetComponent<SpriteRenderer>().sprite = BtmHalfSprite[numobj.Values];
            xy++;
        }        
    }
    public void GenerateDomino()
    {
       for (int i = 0; i < DominoSpawnSlots; i++)
        {
            //Generate a random number between x and y for the top number     
            topValue = UnityEngine.Random.Range(0, 6);
            //Generate a random number between x and y for the bottom number
            TopHalfValues.Add(topValue);
            bottomValue = UnityEngine.Random.Range(0, 6);
            BtmHalfValues.Add(bottomValue);
        }                  
        //topnumber + bottomNumber = totalNumber     
        totalValue = topValue + bottomValue;
        SetSprite(topValue, bottomValue);
        //Dominos have ended...go to pizza hut
        dominosSpawned.Invoke();
    }
    void Start()
    {        
        for (int i = 0; i < DominoSpawnSlots; i++)
        {
            slots = Instantiate(DominoSpawnSlotPrefab, transform) as GameObject;//this will spawn an instance of the dominoslot prefab within the domino group
            spawn = Instantiate(DominoDragPrefab) as GameObject;
            spawn.transform.SetParent(slots.transform);
            spawn.gameObject.name = "domino"+i;
            TopHalf = Instantiate(TopHalfPrefab) as GameObject;
            TopHalf.transform.SetParent(spawn.transform);
            BtmHalf = Instantiate(BtmHalfPrefab) as GameObject;
            BtmHalf.transform.SetParent(spawn.transform);         
        }
        GenerateDomino();
    }

    // Update is called once per frame
    void Update()
    {

    }
}