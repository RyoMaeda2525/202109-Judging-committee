using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerManager : MonoBehaviour 
{ 
    public float m_speed = 3;
    Vector3 m_Vector = default;
    Rigidbody2D m_rb = default;
    public GameObject[] Player;
    public Vector3 scale = default;
    //Transform a = default;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
       // a = GetComponent<Transform>();
        Player = GameObject.FindGameObjectsWithTag("Player");
        scale = Player[0].transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_scale = transform.localScale;
          // a = this.transform.rotation;
        if (scale.x <= -1)
        {
            m_scale.x = -1;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 55);
        }
        else
        {
            m_scale.x = 1;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45);
        }
        m_rb.velocity = new Vector2(m_speed * m_scale.x, m_rb.velocity.y);
        transform.localScale = m_scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Enemy")
        GameObject.Destroy(gameObject);
    }
}
