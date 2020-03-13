using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Allows us to save this data to a file
public class PlayerData
{
    public int currLevel;
    public float currHealth;
    public float currTime;
    public float maxHealth;
    public float[] playerPosition;

    public PlayerData(GameLoop gameLoop)
    {
        currLevel = gameLoop.currLevel;
        currHealth = gameLoop.currHealth;
        currTime = gameLoop.timer;
        maxHealth = gameLoop.maxHealth;

        // Capturing Pablo's Position
        playerPosition = new float[3]; // Since we can't save vectors in files, we must create an array of the vector's elements
        playerPosition[0] = gameLoop.pablo.transform.position.x;
        playerPosition[1] = gameLoop.pablo.transform.position.y;
        playerPosition[2] = gameLoop.pablo.transform.position.z;
    }
}