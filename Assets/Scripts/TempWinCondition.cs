using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWinCondition : MonoBehaviour
{
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Win");
            gameManager.GetComponent<GameLoop>().Pause();
            gameManager.GetComponent<SceneSwitch>().LoadNextLevel();
        }
    }
}
