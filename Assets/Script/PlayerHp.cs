using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    public PlayerManager m_PlaMan = default;
    public int myHealth = 2;
    public int i = 0;
    public float m_moveSpeed = 1;
    public float Jumppower = 1;
    public bool isDamage = false;
    public float m_KnockBackPawarSave = 5;
    private SpriteRenderer sp = default;
    GameManager gm = default;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_PlaMan = GetComponent<PlayerManager>();
        sp = GetComponent<SpriteRenderer>();
        gm = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
        }
    }

    public void Damage()
    {
        if (!isDamage)
        {
            isDamage = true;
            StartCoroutine(Knockback());
            gm.PlayerDead();
        }
    }



    public IEnumerator  Knockback()
    {
        yield return new WaitForSeconds(3.0f);
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }


}
