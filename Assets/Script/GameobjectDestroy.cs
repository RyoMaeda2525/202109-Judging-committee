﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Manager" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {

        }
        else
        {
            GameObject a = collision.gameObject;
            Debug.Log(a.name);
            GameObject.Destroy(a);
        }  
    }
}
