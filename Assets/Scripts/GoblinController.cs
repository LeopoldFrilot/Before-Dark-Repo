using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "fx_weapon" || col.gameObject.name == "Bip001 Prop2")
        {
            Debug.Log("Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
