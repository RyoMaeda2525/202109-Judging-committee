using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHorizontal : MonoBehaviour
{
    public float m_speed = 0.5f;
    Rigidbody2D m_rb = default;
    public bool pushOnAwake = true;
    public Vector3 startDirection;
    public float m_moveSpeed = 1;
    public float dethtimer = 6;
    public GameObject fieryEffect;
    public GameObject smokeEffect;
    public GameObject explodeEffect;
    private CircleCollider2D[] circle = default;

    public void Awake()
    {
        //circle = GetComponentsInChildren<CircleCollider2D>();
    }
    void Start()
    {
        circle = GetComponentsInChildren<CircleCollider2D>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = new Vector2(m_speed * -1, m_rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHp>().Damage();
        }
        //rgbd.Sleep();
        if (fieryEffect != null)
        {
            fieryEffect.SetActive(false);
        }
        if (smokeEffect != null)
        {
            smokeEffect.SetActive(false);
        }
        if (explodeEffect != null)
        {

            explodeEffect.SetActive(true);
        }
        StartCoroutine(Destroy());
    }

    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    public void OnEnable()
    {
        if (fieryEffect != null)
            fieryEffect.SetActive(true);
        if (smokeEffect != null)
            smokeEffect.SetActive(true);
        if (explodeEffect != null)
            explodeEffect.SetActive(false);
    }
}


