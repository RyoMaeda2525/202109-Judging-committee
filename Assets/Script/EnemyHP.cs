﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zonbie : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    private MoveManeger move;
    float m_speed = 0.01f;
    float n_speed = 0.01f;
    public int myHealth = 1;

    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
        move = GetComponent<MoveManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag == ("Bullet"))
    //    {
    //        //t = Mathf.PingPong(Time.time * m_speed, 5.0f); 
    //        StartCoroutine(ColorChange());
    //        GetComponent<CapsuleCollider2D>().enabled = false;
    //        m_rb.gravityScale = 0;
    //        move.m_moveSpeed = 0;
    //    }
    //}

    public void Damage(int damage)
    {
        myHealth -= damage;
        if(myHealth <= 0)
        {
            StartCoroutine(ColorChange());
            GetComponent<CapsuleCollider2D>().enabled = false;
            m_rb.gravityScale = 0;
            move.m_moveSpeed = 0;
        }
    }

    public IEnumerator ColorChange()
    {
        //SpriteRenderer.color = Color.Lerp(startColor, endColor, t);
        //if (t >= 1)
        //{
        //    u = Mathf.PingPong(Time.time * n_speed, 2.0f);
        //    SpriteRenderer.color = Color.Lerp(endColor, LastColor, u);
        //}
        GetComponent<Animator>().Play("Deth");
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);

    }
}