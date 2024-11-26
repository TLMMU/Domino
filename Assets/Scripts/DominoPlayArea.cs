using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoPlayArea : MonoBehaviour
{
    private int PlayAreaSlotCounter = 0;
    bool InsideArea = false;
    [SerializeField] public GameObject PlayAreaSlotPrefab;

    private GameObject AreaSlots;
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision_info)
    {
        AreaSlots = Instantiate(PlayAreaSlotPrefab, transform) as GameObject;
    }
        
        
    void Update()
    {
        //if InsideArea == true
    }
}
