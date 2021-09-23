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
    [SerializeField] GameObject m_bulletPrefab = default;
    public int firecount = 3;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        sp = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)  //←nowStateには現在の状態が入っている
        {
            case BossState.StartEnsyutu:
                ani.Play("Start");
                nowState = BossState.Battle;
                break;
            case BossState.Battle:
                timer += Time.deltaTime;
                if (timer >= 3)
                {
                    Fire();
                    timer = 0;
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
                    //sp.color = new Color(1f, 1f, 1f, level);
                }
                break;
            case BossState.ClearEnsyutu:
                //クリア時の処理を書く
                break;
        }
    }

    public void Fire()
    {
        //for(int i = 0; i < firecount; i++)
        //{
        playerpos = GameObject.FindWithTag("Player").transform.position;
        Instantiate(m_bulletPrefab, this.transform.position, Quaternion.identity);
        //}  
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
        myHealth -= damage;
        m_Damage = true;
        StartCoroutine(IsDamage());
    }

    public IEnumerator IsDamage()
    {
        var list = new List<SpriteRenderer>();
        list.AddRange(sp);
        yield return new WaitForSeconds(3f);
        m_Damage = false;
        for (int i = 0; i < list.Count; i++)
        {
            list[i].color = new Color(1f, 1f, 1f, 1f);

        }
    }
}
