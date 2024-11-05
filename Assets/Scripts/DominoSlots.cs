using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DominoSlots : MonoBehaviour
{
    [SerializeField] private int DominoSpawnSlots = 6;//these are how many dominoes that will spawn within this slot
    [SerializeField] private GameObject DominoSpawnSlotPrefab;
    private GameObject slots;
    [SerializeField] private GameObject DominoPrefab;
    private GameObject spawn;
    void Start()
    {
        
        for (int i = 0; i < DominoSpawnSlots; i++)
        {
            slots = Instantiate(DominoSpawnSlotPrefab, transform) as GameObject;//this will spawn an instance of the dominoslot prefab within the domino group
            spawn = Instantiate(DominoPrefab) as GameObject;
            spawn.transform.SetParent(slots.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}