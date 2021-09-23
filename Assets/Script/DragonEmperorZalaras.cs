using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEmperorZalaras : MonoBehaviour
{
    Vector3 playerpos = default;
    private BossState nowState = BossState.StartEnsyutu;
    Animator ani = default;
    Rigidbody2D m_rb = default;
    public int myHealth = 1;
    public bool m_Damage = false;
    private SpriteRenderer[] sp = default;
    int Dethpoint = 0;
    [SerializeField] GameObject m_FireBall = default;
    [SerializeField] GameObject m_FireWall = default;
    [SerializeField] GameObject m_FireWall2 = default;
    [SerializeField] Transform m_muzzle = default;
    public float fireInterval = 3;
    bool firecooldown = false;
    float timer = 0;
    Transform Spawn = default;
    GameManager m_game = default;
    AudioSource audio = default;

    // Start is called before the first frame update
    void Start()
    {
        m_game = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Spawn = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        sp = GetComponentsInChildren<SpriteRenderer>();
        //ani.Play("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Transform Spawn = this.transform;

        switch (nowState)  //←nowStateには現在の状態が入っている
        {
            case BossState.StartEnsyutu:
                break;
            case BossState.Battle:
                if(myHealth <= 0)
                {
                    nowState = BossState.ClearEnsyutu;
                }
                if (!firecooldown)
                {
                    timer += Time.deltaTime;
                    if (timer >= fireInterval)
                    {
                        int i = Random.Range(0,2);
                        Debug.Log("Fire"+i);
                        firecooldown = true;
                        if(i == 0)
                        {
                            ani.Play("Fire");
                        }
                        else
                        {
                            ani.Play("FireWall");
                        }
                        timer = 0;
                    }
                }
                if (m_Damage)
                {
                    var list = new List<SpriteRenderer>();
                    list.AddRange(sp);
                    float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].color = new Color(1f, 1f, 1f, level);
                    }
                }
                break;
            case BossState.ClearEnsyutu:
                ani.Play("Deth");
                break;
        }
    }

    public void Fire()
    {
        playerpos = GameObject.FindWithTag("Player").transform.position;
        Instantiate(m_FireBall, m_muzzle.transform.position, Quaternion.identity);
        audio.Play();
    }

    public void FireWall()
    {
        int r = Random.Range(0,2) ;
        Debug.Log("Wall" + r);
        if(r == 0)
        {
            playerpos = GameObject.FindWithTag("Player").transform.position;
            Instantiate(m_FireWall, m_muzzle.transform.position, Quaternion.identity);
        }
        else
        {
            playerpos = GameObject.FindWithTag("Player").transform.position;
            Instantiate(m_FireWall2, m_muzzle.transform.position, Quaternion.identity);
        }
        audio.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Dethpoint == 0)
        {
            collision.gameObject.GetComponent<PlayerHp>().Damage();
        }
    }

    private enum BossState  //←「BossState」の部分はenumの名前（自分で定義する）
    {
        StartEnsyutu,  //←好きなように名前をつけることができる
        Battle,
        ClearEnsyutu,
    }

    private void BattaleStart()
    {
        nowState = BossState.Battle;
    }

    public void Damage(int damage)
    {
        if(!m_Damage)
        myHealth -= damage;
        m_Damage = true;
        StartCoroutine(IsDamage());
    }

    public IEnumerator IsDamage()
    {
        var list = new List<SpriteRenderer>();
        list.AddRange(sp);
        yield return new WaitForSeconds(0.3f);
        m_Damage = false;
        for (int i = 0; i < list.Count; i++)
        {
            list[i].color = new Color(1f, 1f, 1f, 1f);

        }
    }

    public void CoolDown()
    { 
        firecooldown = false;
        if (this.gameObject.transform.position.x == 7.1 || this.gameObject.transform.position.y == 2.0)
        {
            // ワールド座標を基準に、座標を取得
            Vector3 worldPos = Spawn.position;
            worldPos.x = 7.1f;   // ワールド座標を基準にした、x座標を1に変更
            worldPos.y = 2.0f;    // ワールド座標を基準にした、y座標を1に変更
            this.transform.position = worldPos;  // ワールド座標での座標を設定
        }
    }

    public void BossClear()
    {
        m_game.GameClear();
        this.gameObject.SetActive(false);
    } 

}
