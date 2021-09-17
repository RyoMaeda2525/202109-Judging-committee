using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratPlayerCheck : MonoBehaviour
{
    private string plyerTag = "Player";
    bool plyerStay = false;
    public bool isPlayerStay, isPlayerExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayerInOut()
    {
        if (isPlayerStay)
        {
            plyerStay = true;
        }
        else if(isPlayerExit)
        {
            plyerStay = false;
        }
        isPlayerStay = false;
        isPlayerExit = false;
        return plyerStay;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == plyerTag)
        {
            isPlayerStay = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == plyerTag)
        {
            isPlayerExit = true;
        }
    }

    
}
