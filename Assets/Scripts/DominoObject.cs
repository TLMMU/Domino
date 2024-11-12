using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;

public class DominoObject : MonoBehaviour{

    public int topValue;
    public int bottomValue;
    public int totalValue;
    [SerializeField] public Sprite[] TopHalfSprite;
    [SerializeField] public Sprite[] BtmHalfSprite;
    [SerializeField] GameObject[] TopHalfObjects;
    public void SetSprite(int topValue, int bottomValue)
    {
        //var sprite = Resources.Load<Sprite>("Dominoes.png" + topValue + bottomValue)
        TopHalfSprite = Resources.LoadAll<Sprite>("top_half");//loads our spritesheet in the array
        //int num = UnityEngine.Random.Range(0, TopHalfSprite.Length);        
        //Debug.Log("top" + topValue);
        //Debug.Log("btm" + bottomValue);
        GameObject.FindGameObjectWithTag("TopHalf").GetComponent<SpriteRenderer>().sprite = TopHalfSprite[topValue];
        BtmHalfSprite = Resources.LoadAll<Sprite>("btm_half");
        GameObject.FindGameObjectWithTag("BtmHalf").GetComponent<SpriteRenderer>().sprite = BtmHalfSprite[bottomValue];
        //int num2 = UnityEngine.Random.Range(0, BtmHalfSprite.Length);
    }

    public void GenerateDomino()
    {
        //Generate a random number between x and y for the top number
        topValue = UnityEngine.Random.Range(0, 6);
        //Generate a random number between x and y for the bottom number
        bottomValue = UnityEngine.Random.Range(0, 6);
        //topnumber + bottomNumber = totalNumber.
        totalValue = topValue + bottomValue;
        SetSprite(topValue, bottomValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateDomino();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
