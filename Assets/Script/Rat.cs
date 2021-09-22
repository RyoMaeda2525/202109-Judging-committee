using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    /// <summary>移動速度</summary>
    public float m_moveSpeed = 1f;
    /// <summary>壁を検出するための ray のベクトル</summary>
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    public float Jumppower = 1;
    private Rigidbody2D m_rb = default;
    public ratPlayerCheck m_PlayerCheck;
    bool inPlaer = false;
    public Vector3 playerPosition;
    private Vector3 Scale = default;
    private Vector2 velocity = default;
    [SerializeField] float m_detectDelaySeconds = 1f;
    public float m_timer = 1f;
    bool m_isGround = false;
    Animator m_ani = default;
    public bool PlayerFound = false; 

        void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = m_rb.velocity;
        //inPlaer = m_PlayerCheck.PlayerInOut();
        PlayerFind();
        if (m_PlayerCheck.IsPlayerFound)
        {
            m_timer += Time.deltaTime;
            m_ani.SetBool("JumpPreparation", true);
            if (m_timer > m_detectDelaySeconds && m_isGround)
            {
                m_timer = 0;
                PlayerFound = true;
                Jump();
            }
        }
        else if(m_timer > 0 && PlayerFound == false)
        {
            m_timer = 1;
            m_ani.SetBool("JumpPreparation", false);
        }
        else if(m_timer > 0)
        {
            m_timer = 0;
            m_ani.SetBool("JumpPreparation", false);
        }
        

    }

    private void PlayerFind()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        Transform rat = this.transform;
        Vector3 ratposition = rat.position;
        Scale = transform.localScale;
        if (playerPosition.x <= ratposition.x)
        {
            if (Scale.x == 1)
            {
                // プレイヤーが左の時
                Scale.x = -1; //左向き
            }
        }
        else
        {
            if (Scale.x == -1)
            {
                // プレイヤーが右の時
                Scale.x = 1; // 右向き
            }
        }
        transform.localScale = Scale;
    }

    private void Jump()
    {
        //yield return new WaitForSeconds(1);
        //float target = Scale.x;
        //velocity.y = Jumppower;
        //velocity.x = target * m_moveSpeed;
        //Debug.Log(velocity);
        //m_rb.velocity = velocity;
        m_ani.SetBool("Jump",true);
        Vector2 vero = (Vector2)this.transform.right * m_moveSpeed * transform.localScale.x + Vector2.up * Jumppower;
        m_rb.velocity = vero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            m_isGround = true;
            m_ani.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            m_isGround = false;
        }
    }
}
