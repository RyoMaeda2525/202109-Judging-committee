using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float m_moveSpeed = 1;
    public float uppower = 1;
    public Vector2 velocity;
    Rigidbody2D m_rb = default;
    [SerializeField] Vector2 m_rayForWall = Vector2.zero;
    [SerializeField] Vector2 m_rayForWall2 = Vector2.zero;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask m_wallLayer = 0;
    Vector2 startPosition = default;
    int m_UporDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = m_rb.velocity;
        Move();
    }
    void MoveOnFloor()
    {
        //Vector2 origin = this.transform.position;   // origin は「raycast の始点」である
        //Debug.DrawLine(origin, origin + m_rayForWall);  // ray（光線）を Scene 上に描く
        // Raycast して床の検出を試みる
       // RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_rayForWall, m_rayForWall.magnitude, m_wallLayer);   // hit には ray の衝突情報が入っている
        //if (hit.collider.gameObject.tag == "Wall")
        //{
        //    m_rayForWall *= -1;
        //    Vector3 scale = transform.localScale;
        //    if (scale.x == -1)
        //    {
        //        // 右方向に移動中
        //        scale.x = 1; // そのまま（右向き）
        //    }
        //    else
        //    {
        //        // 左方向に移動中
        //        scale.x = -1; // 反転する（左向き）
        //    }
        //    // 代入し直す
        //    transform.localScale = scale;
        //}
        Vector2 vero = (Vector2)this.transform.right * m_moveSpeed * transform.localScale.x + Vector2.up * uppower;
        m_rb.velocity = vero;
    }

    private void Move()
    {
        float tra = this.transform.position.y;
        if (tra < startPosition.y - 1)
        {
            m_UporDown = 0;
        }
        if (tra > startPosition.y + 1)
        {
            m_UporDown = 1;
        }
        if(m_UporDown == 0)
        {
            Vector2 vero = (Vector2)this.transform.right * m_moveSpeed * transform.localScale.x + Vector2.up * uppower;
            m_rb.velocity = vero;
        }
        else
        {
            Vector2 vero = (Vector2)this.transform.right * m_moveSpeed * transform.localScale.x + Vector2.down * uppower;
            m_rb.velocity = vero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Vector3 scale = transform.localScale;
            if (scale.x == -1)
            {
                // 右方向に移動中
                scale.x = 1; // そのまま（右向き）
            }
            else
            { 
                // 左方向に移動中
                scale.x = -1; // 反転する（左向き）
            }
            // 代入し直す
            transform.localScale = scale;
        }
    }

}
