using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    int maxHealth = 100;
    int curHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "fx_weapon" || col.gameObject.name == "Bip001 Prop2")
        {
            Debug.Log("Hit");
            curHealth -= 10;
            if(curHealth <= 0) Destroy(gameObject);
            Debug.Log(curHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
