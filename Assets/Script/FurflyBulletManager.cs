using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurflyBulletManager : MonoBehaviour
{
    Vector3 playerpos = default;
    Vector2 vero = default;
    Rigidbody2D m_rb = default;
    public float m_moveSpeed = 1;
    public float m_upSpeed = 1;
    public float dethtimer = 6;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.FindWithTag("Player").transform.position;
        m_rb = GetComponent<Rigidbody2D>();
        vero.x = playerpos.x - this.transform.position.x;
        vero.y = playerpos.y - this.transform.position.y;
        vero = vero.normalized * m_moveSpeed;
        m_rb.velocity = vero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > dethtimer)
        {
            destroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHp>().Damage();
            destroy();
        }
    }

    private void destroy()
    {
        GameObject.Destroy(gameObject);
    }


}
