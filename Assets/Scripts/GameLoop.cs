using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    // Calling External Objects for later use
    public GameObject sceneSwitch;
    public GameObject UITime;
    public GameObject UIHealth;

    // Game Design Knobs
    public static float maxStartingTime = 300f;
    public static float maxStartingHealth = 500f;

    // Public static variables are ones that carry over scene to scene
    public static float timer = maxStartingTime;
    public static float health = maxStartingHealth;

    // Start is called before the first frame update
    void Start()
    {
        sceneSwitch = GameObject.Find("/SceneSwitcher");
        UITime = GameObject.Find("/Level UI/Time");
        UIHealth = GameObject.Find("/Level UI/Health");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
        UpdateTime();
        UpdateHealth();
    }

    private void CheckPause()
    {
        //Pause Condition
        if (Input.GetButtonDown("Cancel"))
        {
            sceneSwitch.GetComponent<SceneSwitch>().LoadSettingsScreen();
        }
    }
    public void UpdateTime()
    {
        if(timer >= 0 && sceneSwitch.GetComponent<SceneSwitch>().GetCurrSceneIndex() > 0 && sceneSwitch.GetComponent<SceneSwitch>().GetCurrSceneIndex() < 8)
        {
            timer -= Time.deltaTime * 0.85f;
        }
        else if(timer == 0)
        {
            sceneSwitch.GetComponent<SceneSwitch>().LoadLoseScreen();
        }
        UITime.GetComponent<Text>().text = "Time: " + (int)timer;
    }
    public void UpdateHealth()
    {
        UIHealth.GetComponent<Text>().text = "Health: " + (int)health;
    }
    public void HardReset()
    {
        timer = maxStartingTime;
        health = maxStartingHealth;
    }
}
