using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratPlayerCheck : MonoBehaviour
{
    bool m_isPlayerFound = false;
    public bool IsPlayerFound { get { return m_isPlayerFound; } }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    m_isPlayerFound = true;
        //}
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_isPlayerFound = false;
        }
    }

    public void hit()
    {
        m_isPlayerFound = true;
    }
}
