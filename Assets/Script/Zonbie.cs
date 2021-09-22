using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    private MoveManeger move;
    float m_speed = 0.01f;
    float n_speed = 0.01f;
    [SerializeField] int m_score = 100;
    public int myHealth = 1;
    public Transform m_RatCheck = default;
    public bool m_Damage = false;
    private SpriteRenderer sp = default;
    // Start is called before the first frame update
    int Dethpoint = 0;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
        move = GetComponent<MoveManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
        }
    }

    public void Damage(int damage)
    {
        m_Damage = true;
        StartCoroutine(IsDamage());
        myHealth -= damage;
        if (myHealth <= 0)
        {
            StartCoroutine(ColorChange());
            Dethpoint = 1;
            m_rb.gravityScale = 0;
        }
    }

    public IEnumerator IsDamage()
    {
        yield return new WaitForSeconds(1.5f);
        m_Damage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }

    public IEnumerator ColorChange()
    {
        GameManager gm = GameManager.FindObjectOfType<GameManager>();
        if (gm)
        {
            gm.AddScore(m_score);
        }
        GetComponent<CapsuleCollider2D>().enabled = !enabled;
        m_rb.gravityScale = 0;
        GetComponent<Animator>().Play("Deth");
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.name == "rat" && collision.tag == "Player")
        {
            m_RatCheck.GetComponent<ratPlayerCheck>().hit();
        }
        else if (collision.gameObject.tag == "Player" && Dethpoint == 0)
            {
                collision.gameObject.GetComponent<PlayerHp>().Damage();
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Dethpoint == 0)
        {
            collision.gameObject.GetComponent<PlayerHp>().Damage();
        }
    }
}
