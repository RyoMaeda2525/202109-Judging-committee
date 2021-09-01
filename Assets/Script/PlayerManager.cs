using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    public float walkForce = 0.85f; //スピード
    public float flyForce = 2.5f; //ジャンプ力
    [Range(0, 1)] public float sliding = 0.9f; //スライドモーション
    public GroundCheck ground;//接地判定用object
    public bool isGround = false;//接地判定
    private Animator anim = default;
    public int j = 0;//ジャンプカウンター

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        Vector2 velocity = m_rb.velocity;
        if (h != 0)
        {
            // 左右の移動
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * walkForce, v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
            Vector2 f = new Vector2(h, 0).normalized * walkForce;
            m_rb.AddForce(f);
        }
        else
        {
            // スライドモーション
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);

        }
        if (Input.GetButtonDown("Jump") )
        {
            if(j <= 1)
            {
                
                velocity.y = flyForce;
                m_rb.velocity = velocity;
                j += 1 ;
            }
                
        }
        if(isGround == true)
        {
            j = 0;
        }
    }
}
