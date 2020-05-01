using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int initialChestNum = 20;
    public int groceriesCollected = 0;
    public int groceriesToCollect = 10;

    // boundaries of the map
    public float maxPosX = 100f;
    public float maxNegX = -500f;
    public float maxPosZ = 100f;
    public float maxNegZ = -200f;
    public float dropHeight = 50f;

    public GameObject Chest;
    public GameObject slot1;

    // Start is called before the first frame update
    void Start()
    {
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

    public void SpawnChests(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(Chest, new Vector3(UnityEngine.Random.Range(maxNegX, maxPosX), dropHeight, UnityEngine.Random.Range(maxNegZ, maxPosZ)), Quaternion.identity);
        }

    }
}
