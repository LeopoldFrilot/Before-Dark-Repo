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
        health = gameObject.transform.GetChild(0).gameObject;
        time = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        health.GetComponent<Text>().text = "Health: " + (int)gameManager.GetComponent<GameLoop>().currHealth;
        time.GetComponent<Text>().text = "Time: " + (int)gameManager.GetComponent<GameLoop>().timer;
    }
}
