using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int initialChestNum = 10;

    // boundaries of the map
    public float maxPosX = 100f;
    public float maxNegX = -500f;
    public float maxPosZ = 100f;
    public float maxNegZ = -200f;
    public float dropHeight = 500f;



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

    }
}
