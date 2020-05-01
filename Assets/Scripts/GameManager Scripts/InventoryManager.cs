using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;

public class InventoryManager : MonoBehaviour
{
    public int initialChestNum = 20;
    public int groceriesCollected = 0;
    public int groceriesToCollect = 10;

    // boundaries of the map

    public float maxPosX;
    public float maxNegX;
    public float maxPosZ;
    public float maxNegZ;
    public float dropHeight = 50f;

    public GameObject Chest;
    public GameObject slot1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<GameLoop>().currLevel);
        FillInBoundaries(GetComponent<GameLoop>().currLevel);
        SpawnChests(initialChestNum);
        slot1 = GameObject.Find("Slot (1)");
    }

    // Update is called once per frame
    void Update()
    {
        Transform number = slot1.transform.Find("Number");
        if (groceriesCollected <= groceriesToCollect)
        {
            number.GetComponent<TextMeshProUGUI>().text = "" + groceriesCollected;
        }

    }

    private void FillInBoundaries(int num)
    {
        if(num == 1)
        {
            maxPosX = 100f;
            maxNegX = -500f;
            maxPosZ = 100f;
            maxNegZ = -200f;
        }
        if(num == 2)
        {
            maxPosX = 980f;
            maxNegX = 530f;
            maxPosZ = 730f;
            maxNegZ = -300f;
        }
    }
    public void SpawnChests(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(Chest, new Vector3(UnityEngine.Random.Range(maxNegX, maxPosX), dropHeight, UnityEngine.Random.Range(maxNegZ, maxPosZ)), Quaternion.identity);
        }

    }
}
