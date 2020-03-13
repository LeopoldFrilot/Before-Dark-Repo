using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Calling External Objects for later use

    // Game Design Knobs
    [SerializeField] float maxTime = 300f;
    [SerializeField] float startingHealth = 500f;

    // Local Variables
    float timer;
    float currHealth;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        currHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
        UpdateTime();
        UpdateHealth();
    }

    public void CheckPause()
    {
        //Pause Condition
        if (Input.GetButtonDown("Cancel"))
        {
            GetComponent<SceneSwitch>().LoadPauseScreen();
        }
    }
    public void UpdateTime()
    {
        if(timer >= 0) // && GetComponent<SceneSwitch>().GetCurrSceneIndex() > 0 && GetComponent<SceneSwitch>().GetCurrSceneIndex() < 8)
        {
            timer -= Time.deltaTime;
        }
        else if(timer == 0)
        {
            GetComponent<SceneSwitch>().LoadLoseScreen();
        }
    }
    public void UpdateHealth()
    {
    }
}
