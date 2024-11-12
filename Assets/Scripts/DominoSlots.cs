using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEditorInternal.VersionControl;

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
        //var sprite = Resources.Load<Sprite>("Dominoes.png" + topValue + bottomValue)
        TopHalfSprite = Resources.LoadAll<Sprite>("top_half");//loads our spritesheet in the array
        BtmHalfSprite = Resources.LoadAll<Sprite>("btm_half");
        //int num = UnityEngine.Random.Range(0, TopHalfSprite.Length);
        //int num2 = UnityEngine.Random.Range(0, BtmHalfSprite.Length);
        TopHalfObjects = GameObject.FindGameObjectsWithTag("TopHalf");
        BtmHalfObjects = GameObject.FindGameObjectsWithTag("BtmHalf");

        int[] ValuesArray = TopHalfValues.ToArray();
        //var objandvalues = ValuesArray.Zip(TopHalfObjects, (first, second) => first + " " + second);
        //foreach (var item in objandvalues)
        //{
        //    TopHalf.GetComponent<SpriteRenderer>().sprite = TopHalfSprite[TopHalfValues[0]];
        //
        foreach (GameObject TopHalf in TopHalfObjects)
        {
            for (int i = 0; i < TopHalfValues.Count; i++)
            {
                TopHalf.GetComponent<SpriteRenderer>().sprite = TopHalfSprite[TopHalfValues[i]];              
            }
            
        }

        foreach (GameObject BtmHalf in BtmHalfObjects)
        {            
            foreach (int i in ValuesArray)
            {
                BtmHalf.GetComponent<SpriteRenderer>().sprite = BtmHalfSprite[BtmHalfValues[i]];
            }

        }
    }

    public void GenerateDomino()
    {
       for (int i = 0; i < 6; i++)
        {
            topValue = UnityEngine.Random.Range(0, 6);
            TopHalfValues.Add(topValue);
            bottomValue = UnityEngine.Random.Range(0, 6);
            BtmHalfValues.Add(bottomValue);
        }
        //Generate a random number between x and y for the top number        
        //Generate a random number between x and y for the bottom number
        //topnumber + bottomNumber = totalNumber.
        
        //topValue = UnityEngine.Random.Range(0, 6);
        //bottomValue = UnityEngine.Random.Range(0, 6);
        totalValue = topValue + bottomValue;
        SetSprite(topValue, bottomValue);
    }
    void Start()
    {
        
        for (int i = 0; i < DominoSpawnSlots; i++)
        {
            slots = Instantiate(DominoSpawnSlotPrefab, transform) as GameObject;//this will spawn an instance of the dominoslot prefab within the domino group
            spawn = Instantiate(DominoDragPrefab) as GameObject;
            spawn.transform.SetParent(slots.transform);
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