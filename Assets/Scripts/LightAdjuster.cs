using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjuster : MonoBehaviour
{
    public float startingSunRotation = 90f; // Represents 12:00
    public float maxSunRotation = 180f; // Sun sets here
    public GameObject sun;
    private float amntRotated;
    private float currRotation;
    private int count;
    public float lightSections = 200f;
    GameLoop gameLoop;

    // Start is called before the first frame update
    void Start()
    {
        // initiating sun height
        Vector3 startingSun = new Vector3(startingSunRotation, 0, 0);
        sun.transform.rotation = Quaternion.Euler(startingSun);

        gameLoop = gameObject.GetComponent<GameLoop>();
        amntRotated = (maxSunRotation - startingSunRotation)/lightSections;
        count = ((int)lightSections) - 1;
        currRotation = startingSunRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLoop.timer >= 0 && gameLoop.timer <= count * gameLoop.maxTime / lightSections)
        {
            currRotation += amntRotated;
            Vector3 deltaRot = new Vector3(currRotation, 0, 0);
            sun.transform.rotation = Quaternion.Euler(deltaRot);
            count--;
        }
    }
}
