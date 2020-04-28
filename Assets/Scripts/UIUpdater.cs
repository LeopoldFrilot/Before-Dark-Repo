﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject health;
    public GameObject time;
    public GameObject timeSlider;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateTime();
        CheckPause();
    }
    private void UpdateHealth()
    {
        health.GetComponent<Text>().text = "Health: " + (int)gameManager.GetComponent<GameLoop>().currHealth;
    }
    private void UpdateTime()
    {
        float timeFound = gameManager.GetComponent<GameLoop>().timer;
        float maxTime = gameManager.GetComponent<GameLoop>().maxTime;
        time.GetComponent<Text>().text = "Time: " + (int)timeFound;
        timeSlider.GetComponent<Slider>().value = 1-(timeFound / maxTime);
    }
    private void CheckPause()
    {
        if (gameManager.GetComponent<GameLoop>().IsPaused())
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }
    }
}
