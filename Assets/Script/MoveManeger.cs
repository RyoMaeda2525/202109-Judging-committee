using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManeger : MonoBehaviour
{
    /// <summary>移動速度</summary>
    public float m_moveSpeed = 1f;
    /// <summary>壁を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForWall = Vector2.zero;
    [SerializeField] Vector2 m_rayForWall2 = Vector2.zero;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask m_wallLayer = 0;
    /// <summary>床を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForGround = Vector2.zero;
    /// <summary>床のレイヤー</summary>
    [SerializeField] LayerMask m_groundLayer = 0;
    [SerializeField] LayerMask m_FloorgroundLayer = 0;
    Rigidbody2D m_rb = default;
    Vector2 migi = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnFloor();
    }

    void MoveOnFloor()
    {
        Vector2 origin = this.transform.position;   // origin は「raycast の始点」である
        Debug.DrawLine(origin, origin + m_rayForWall);  // ray（光線）を Scene 上に描く
        Debug.DrawLine(origin, origin + m_rayForGround);    // ray を Scene 上に描く
        // Raycast して床の検出を試みる
        RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, m_rayForGround, m_rayForGround.magnitude,m_groundLayer + m_FloorgroundLayer);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position ,m_rayForWall, m_rayForWall.magnitude, m_wallLayer);   // hit には ray の衝突情報が入っている
        Vector2 dir = Vector2.zero; // dir は速度ベクトル
        //if (hit.collider)
        //{
        //    migi = new Vector2(migi.x * -1, migi.y);
        //    m_rayForWall *= -1;
        //    m_rayForGround.x *= -1;

        //}
        if (!hit2.collider || hit.collider)
        {
            migi = new Vector2(migi.x * -1, migi.y);
            m_rayForWall *= -1;
            m_rayForGround.x *= -1;
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
        dir = migi * m_moveSpeed;
        dir.y = m_rb.velocity.y;    // 落下については現在の値を採用する
        m_rb.velocity = dir;    // 速度ベクトルをセットする
    }
}
