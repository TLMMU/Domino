using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] Sprite [] DominoSprites; 
    [SerializeField] SpriteRenderer SpriteRenderer;

    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        DominoSprites = Resources.LoadAll<Sprite>("Assets/Sprites/Resources/Dominoes");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
