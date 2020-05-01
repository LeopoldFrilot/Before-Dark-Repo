using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int initialChestNum = 20;

    // boundaries of the map
    public float maxPosX = 100f;
    public float maxNegX = -500f;
    public float maxPosZ = 100f;
    public float maxNegZ = -200f;
    public float dropHeight = 50f;

    public GameObject Chest;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChests(initialChestNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChests(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(Chest, new Vector3(UnityEngine.Random.Range(maxNegX, maxPosX), dropHeight, UnityEngine.Random.Range(maxNegZ, maxPosZ)), Quaternion.identity);
        }

    }
}
