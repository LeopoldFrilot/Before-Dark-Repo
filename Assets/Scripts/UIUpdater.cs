using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject health;
    public GameObject time;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        health.GetComponent<Text>().text = "Health: " + (int)gameManager.GetComponent<GameLoop>().currHealth;
        time.GetComponent<Text>().text = "Time: " + (int)gameManager.GetComponent<GameLoop>().timer;
    }
}
