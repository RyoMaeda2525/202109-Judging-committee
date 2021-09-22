using System.Collections;
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

    public void Damage(int damage)
    {
        myHealth -= damage;
        if (myHealth <= 0)
        {
            StartCoroutine(ColorChange());
            GetComponent<CapsuleCollider2D>().enabled = false;
            m_rb.gravityScale = 0;
            move.m_moveSpeed = 0;
        }
    }

    public IEnumerator ColorChange()
    {
        GetComponent<Animator>().Play("Deth");
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<PlayerHp>().Damage();
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<PlayerHp>().Damage();
        //}
    }
}
