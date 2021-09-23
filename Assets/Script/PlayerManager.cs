using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    [SerializeField] GameObject m_bulletPrefab = default;
    [SerializeField] GameObject m_bulletPrefab2 = default;
    [SerializeField] GameObject m_bulletPrefabReinforcement = default;
    [SerializeField] GameObject m_bulletPrefabReinforcement2 = default;
    public float walkForce = 0.85f; //スピード
    public float flyForce = 2.5f; //ジャンプ力
    [Range(0, 1)] public float sliding = 0.9f; //スライドモーション
    public GroundCheck ground;//接地判定用object
    public bool isGround = false;//接地判定
    private Animator anim = default;
    public GameObject Bullet = default;  
    [SerializeField] Transform m_muzzle = default;
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    public int jumpCount = 0;//ジャンプカウンター
    Transform m_tra = default;
    public bool GroundCheck = false;
    private bool isGroundCheck = false;
    public Vector3 scale = default;
    public int dagerCount = 0;
    public int dagerReinforcementCount = 0;
    public bool m_Attack = false;
    public PlayerHp playerhp = default;
    public GameManager gm = default;
    private bool m_AttackRapidfire = false;
    private bool isBossGround = false;
    private bool BossGroundCheck = false;

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
        dagerCount = Bullet.transform.GetComponentsInChildren<DaggerManager>().Length;
        dagerReinforcementCount = Bullet.transform.GetComponentsInChildren<DaggerReinforcementManager>().Length;
        isGround = ground.IsGround();
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        Vector2 velocity = m_rb.velocity;
        if (playerhp.i == 0)
        {
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
                if (jumpCount <= 0)
                {
                    velocity.y = flyForce;
                    m_rb.velocity = velocity;
                    jumpCount += 1;
                }

            }
            if (isGround == true)
            {
                anim.SetBool("Jump", false);
                jumpCount = 0;
            }
            if (isGround == false)
            {
                anim.SetBool("Jump", true);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                    //AttackStart();
                anim.SetBool("isAttack", true);
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

    public bool BossFloor()
    {
        if (isBossGround)
        {
            BossGroundCheck = true;
        }
        isBossGround = false;
        return  BossGroundCheck;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundCheck")
        { 
            Destroy(collision.gameObject);
            isGroundCheck = true;
        }
        if(collision.tag == "BossGround")
        {
            Debug.Log("a");
            Destroy(collision.gameObject);
            isBossGround = true;
        }
    }

    public void AddSpead(float speed)
    {
        walkForce += speed;
    }

    private void AttackStart()
    {
        //m_Attack = true;
        anim.SetBool("isAttack", true);
    }


    public void Attack()
    {
        if (m_bulletLimit == 0 || dagerCount + dagerReinforcementCount < m_bulletLimit)    // 画面内の弾数を制限する
        {
             if (gm.m_life == 3 && jumpCount != 0)
            {
                GameObject go4 = Instantiate(m_bulletPrefabReinforcement2, this.m_muzzle.position, Quaternion.identity);
                go4.transform.SetParent(Bullet.transform);
            }
            else if (gm.m_life == 3)
            {
                GameObject go3 = Instantiate(m_bulletPrefabReinforcement, this.m_muzzle.position, Quaternion.identity);
                go3.transform.SetParent(Bullet.transform);
            }
            else if (jumpCount != 0)
            {
                GameObject go2 = Instantiate(m_bulletPrefab2, this.m_muzzle.position, Quaternion.identity);
                go2.transform.SetParent(Bullet.transform);
            }
            else
            {
                GameObject go = Instantiate(m_bulletPrefab, this.m_muzzle.position, Quaternion.identity);
                go.transform.SetParent(Bullet.transform);
            }
        }
        //m_Attack = false;
    }

    public void AttackCoolDown()
    {
        //m_Attack = false;
        //anim.SetBool("isAttack", false);
    }

    public void Dead()
    {
        anim.Play("Dead");
    }

    

}
