﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    [SerializeField] GameObject m_bulletPrefab = default;
    public float walkForce = 0.85f; //スピード
    public float flyForce = 2.5f; //ジャンプ力
    [Range(0, 1)] public float sliding = 0.9f; //スライドモーション
    public GroundCheck ground;//接地判定用object
    public bool isGround = false;//接地判定
    private Animator anim = default;
    public GameObject Bullet = default;
    [SerializeField] Transform m_muzzle = default;
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    private int j = 0;//ジャンプカウンター
    Transform m_tra = default;
    public LayerMask whatIsGround;
    public bool GroundCheck = false;
    private bool isGroundCheck = false;
    public Vector3 scale = default;
    public int a = 0;
    public bool m_Attack = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        m_tra = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        a = this.GetComponentsInChildren<DaggerManager>().Length;
        isGround = ground.IsGround();
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        Vector2 velocity = m_rb.velocity;
        if (h != 0)
        {
            anim.SetBool("walk", true);
            // 左右の移動
            m_rb.velocity = new Vector2(h * walkForce, v.y);
            m_tra.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
            Vector2 f = new Vector2(h, 0).normalized * walkForce;
            m_rb.AddForce(f);
        }
        else
        {
            // スライドモーション
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);
            anim.SetBool("walk", false);

        }
        if (Input.GetButtonDown("Jump"))
        {
            if (j <= 0)
            {
                velocity.y = flyForce;
                m_rb.velocity = velocity;
                j += 1;
            }

        }
        if (isGround == true)
        {
            anim.SetBool("Jump", false);
            j = 0;
        }
        if(isGround == false)
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (m_Attack == false)
            {
                StartCoroutine(AttackStart()); 
            }
        }
    }
    public bool Floor()
    {
        if (isGroundCheck)
        {
            GroundCheck = true;
        }
        isGroundCheck = false;
        return GroundCheck;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundCheck")
        {
            isGroundCheck = true;

        }
    }

    public void AddSpead(float speed)
    {
        walkForce += speed;
    }

    private IEnumerator AttackStart()
    {
        m_Attack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1f);
    }

    
    public void Attack()
    {
        if (m_bulletLimit == 0 || Bullet.GetComponentsInChildren<DaggerManager>().Length < m_bulletLimit)    // 画面内の弾数を制限する
        {
            GameObject go = Instantiate(m_bulletPrefab, this.m_muzzle.position, Quaternion.identity);
            go.transform.SetParent(Bullet.transform); 
        }
    }

    public void AttackCoolDown()
    {
        Debug.Log("a");
        anim.SetBool("isAttack", false);
        m_Attack = false;
    }
}
