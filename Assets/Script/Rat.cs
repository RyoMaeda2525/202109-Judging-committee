using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    /// <summary>移動速度</summary>
    public float m_moveSpeed = 1f;
    /// <summary>壁を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForWall = Vector2.zero;
    [SerializeField] Vector2 m_rayForWall2 = Vector2.zero;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask m_wallLayer = 0;
    public float Jumppower = 1;
    private Rigidbody2D m_rb = default;
    public ratPlayerCheck m_PlayerCheck;
    bool inPlaer = false;
    // public GameObject m_Player = default;
    //public Vector3 scale;
    //public Vector3 playerScale;
    public Vector3 playerPosition;
    private Vector3 Scale = default;
    private Vector2 velocity = default;

        void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = m_rb.velocity;
        inPlaer = m_PlayerCheck.PlayerInOut();
        //MoveOnFloor();
        PlayerFind();
        if (inPlaer)
        {
            StartCoroutine(JumpStop());
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

    private IEnumerator JumpStop()
    {
        yield return new WaitForSeconds(1);
        float target = Scale.x;
        velocity.y = Jumppower;
        velocity.x = target * m_moveSpeed;
        Debug.Log(velocity);
        m_rb.velocity = velocity;
    }
}
