using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public AudioClip soundClip;
    public GameObject MainCamera; //Contains the audio source
    AudioSource audioSource;
    Rigidbody chest;
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        chest = GetComponent<Rigidbody>();
        MainCamera = GameObject.Find("Main Camera");
        audioSource = MainCamera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(chest.velocity == new Vector3(0,0,0))
        {
            isVisible = true;
        }
        if (isVisible)
        {
            gameObject.transform.Find("chest_close").GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.transform.Find("chest_close").GetComponent<Renderer>().enabled = false;
        }*/
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Stick.R" )//|| col.gameObject.name == "Bip001 Prop2")
        {
            Debug.Log("Chest Opened!");
            audioSource.PlayOneShot(soundClip, 0.5f);
            AddRandomItem(UnityEngine.Random.Range(0f, 9f));
            AddGroceryItem();
            Destroy(gameObject);
        }
    }
    private void AddGroceryItem()
    {

    }

    private void AddRandomItem(float num)
    {

    }
}
