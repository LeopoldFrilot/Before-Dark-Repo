using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLoop : MonoBehaviour
{
    // Calling External Objects for later use
    public GameObject pablo;

    // Variables for function
    public float autoSaveWindow = 10f;
    float timeWithoutSave = 0f;
    public float timerPenaltyForDying = 10f;
    public int currLevel;

    // Variables to be saved/stored
    public float maxTime = 300f;
    public float maxHealth = 500f;
    public float timer;
    public float currHealth;

    // Possible states that the game can be in
    enum State { Play, Pause}
    State state;
 

    // Start is called before the first frame update
    void Start()
    {
        state = State.Play;
        currLevel = GetComponent<SceneSwitch>().GetCurrSceneIndex();
        if(currLevel == 1)
        {
            timer = maxTime;
            currHealth = maxHealth;
        }
        else
        {
            LoadState();
            pablo.transform.position = StartingPlacePerLevel(currLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Play)
        {
            CheckInputs();
            UpdateTime();
            CheckAutosave();
        }
        /*else if(state == State.Pause)
        {

        }
        else
        {
            // No other states yet
        }*/
    }

    private void CheckInputs()
    {
        if (Input.GetButtonDown("Cancel")) // "esc" button to pause
        {
                Debug.Log("Pause game");
                state = State.Pause;
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
    private void CheckAutosave()
    {
        timeWithoutSave += Time.deltaTime;
        if (timeWithoutSave >= autoSaveWindow)
        {
            print("autosaving...");
            SaveState();
            timeWithoutSave = 0f;
        }
    }
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

    public void Resume()
    {
        // Create Pause screen
        Debug.Log("Resume game");
        state = State.Play;
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void Save()
    {
        Debug.Log("Saving...");
        Invoke("SaveState", 1f);
        Debug.Log("Saved");
    }

    public void Load()
    {
        Debug.Log("Loading...");
        Invoke("LoadState", 1f);
        Debug.Log("Loaded");
        Invoke("Resume",.5f);
    }
    public bool IsPaused()
    {
        if (state == State.Pause)
            return true;
        else
            return false;
    }

    public void SaveState()
    {
        SaveManager.SaveState(this);
    }
    public void LoadState() // Loading completely from nothing (mainly used for the continue button)
    {
        PlayerData data = SaveManager.LoadState();
        // currLevel = data.currLevel;  This SHOULD not be needed, but I'll keep it here for now
        currHealth = data.currHealth;
        timer = data.currTime;
        maxHealth = data.maxHealth;

        Vector3 loadedPosition;
        loadedPosition.x = data.playerPosition[0];
        loadedPosition.y = data.playerPosition[1];
        loadedPosition.z = data.playerPosition[2];
        pablo.transform.position = loadedPosition;
        Debug.Log(pablo.transform.position);
        GetComponent<LightAdjuster>().InitializeSun(); // The sun will go back where it needs to based on the time.
    }
}
