using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoObject : MonoBehaviour
{
    public int topValue;
    public int bottomValue;
    public int totalValue;

    public void SetSprite(int topValue, int bottomValue)
    {
        //Load a Sprite (Assets/Resources/Sprites/sprite01.png)
        var sprite = Resources.Load<Sprite>("Individual/" + topValue + bottomValue);

        //if topvalue == 0
        //if bottomvalue == 0 
    }

    public void GenerateDomino()
    {
        //Generate a random number between x and y for the top number
        topValue = Random.Range(0,6);
        //Generate a random number between x and y for the bottom number
        bottomValue = Random.Range(0,6);
        //topnumber + bottomNumber = totalNumber.
        totalValue = topValue + bottomValue;
        SetSprite(topValue, bottomValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
