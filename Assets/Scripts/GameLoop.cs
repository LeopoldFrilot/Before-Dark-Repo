using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLoop : MonoBehaviour
{
    // Calling External Objects for later use
    public GameObject pablo;

    // Variables for function
    public float autoSaveWindow = 10f;
    // float timeWithoutSave = 0f;
    public float timerPenaltyForDying = 10f;

    // Variables to be saved/stored
    public float maxTime = 300f;
    public float maxHealth = 500f;
    public float timer;
    public float currHealth;
    public int currLevel; 

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        currHealth = maxHealth;
        currLevel = GetComponent<SceneSwitch>().GetCurrSceneIndex();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
        UpdateTime();
        // CheckAutosave();
    }

    public void CheckPause()
    {
        // Saves for now
        if (Input.GetButtonDown("Save")) // "=" button
        {
            Debug.Log("Saved");
            SaveState();
        }
        // Loads save for now
        if(Input.GetButtonDown("Load")) // "-" button
        {
            Debug.Log("Loaded");
            LoadState();
        }
    }
    private void UpdateTime()
    {
        if(timer >= 0 && currLevel > 0 && currLevel < 8)
        {
            timer -= Time.deltaTime;
        }
        else if(timer == 0)
        {
            GetComponent<SceneSwitch>().LoadLoseScreen();
        }
    }
    /*private void CheckAutosave()
    {
        timeWithoutSave += Time.deltaTime;
        if (timeWithoutSave >= autoSaveWindow)
        {
            SaveState();
            timeWithoutSave = 0f;
        }
    }*/
    public void UpdateHealth(float deltaHealth)
    {
        currHealth += deltaHealth;
        if(currHealth <= 0)
        {
            pablo.transform.position = StartingPlacePerLevel(currLevel);
            timer -= timerPenaltyForDying;
            currHealth = maxHealth;
        }
    }// Will be called when Pablo is hit or consumes a snack
    public void SaveState()
    {
        SaveManager.SaveState(this);
    }
    public void LoadState() // Loading completely from nothing (mainly used for the continue button)
    {
        PlayerData data = SaveManager.LoadState();
        currLevel = data.currLevel;
        currHealth = data.currHealth;
        timer = data.currTime;
        maxHealth = data.maxHealth;

        Vector3 loadedPosition;
        loadedPosition.x = data.playerPosition[0];
        loadedPosition.y = data.playerPosition[1];
        loadedPosition.z = data.playerPosition[2];
        pablo.transform.position = loadedPosition;
    }
    public Vector3 StartingPlacePerLevel(int levelNum) // To be edited later
    {
        if (levelNum == 1)
            return new Vector3(0, 0, 0);
        if (levelNum == 2)
            return new Vector3(0, 0, 0);
        if (levelNum == 3)
            return new Vector3(0, 0, 0);
        if (levelNum == 4)
            return new Vector3(0, 0, 0);
        if (levelNum == 5)
            return new Vector3(0, 0, 0);
        else
            return new Vector3(0, 0, 0);
    }
}
