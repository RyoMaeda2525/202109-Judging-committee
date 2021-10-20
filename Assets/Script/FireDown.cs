using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDown : MonoBehaviour
{
    public bool pushOnAwake = true;
    public Vector3 startDirection;
    public float startMagnitude;
    public ForceMode2D forceMode2D;
    Vector3 playerpos = default;
    Vector2 vero = default;
    public float m_moveSpeed = 1;
    public float dethtimer = 6;
    public GameObject fieryEffect;
    public GameObject smokeEffect;
    public GameObject explodeEffect;
    protected Rigidbody2D rgbd;
    private CircleCollider2D[] circle = default;


    public void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        circle = GetComponentsInChildren<CircleCollider2D>();
    }

    public void Start()
    {
        //if (pushOnAwake)
        //{
        //    Push(startDirection, startMagnitude);
        //}
        rgbd = GetComponent<Rigidbody2D>();
        //playerpos = GameObject.FindWithTag("Player").transform.position;
        //vero.x = playerpos.x - this.transform.position.x;
        //vero.y = playerpos.y - this.transform.position.y;
        //vero = vero.normalized * m_moveSpeed;
        //rgbd.velocity = vero;
        Destroy();
    }

    //public void Push(Vector3 direction, float magnitude)
    //{
    //    Vector3 dir = direction.normalized;
    //    rgbd.AddForce(dir * magnitude, forceMode2D);
    //}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHp>().Damage();
        }
        //rgbd.Sleep();
        if (fieryEffect != null)
        {
            fieryEffect.SetActive(false);
        }
        if (smokeEffect != null)
        {
            smokeEffect.SetActive(false);
        }
        if (explodeEffect != null)
        {

            explodeEffect.SetActive(true);
        }
        StartCoroutine(Destroy());
    }

    //public void StopParticleSystem(GameObject g)
    //{
    //    ParticleSystem[] par;
    //    par = g.GetComponentsInChildren<ParticleSystem>();
    //    foreach(ParticleSystem p in par)
    //    {
    //        p.Stop();
    //    }
    //}

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    public void OnEnable()
    {
        if (fieryEffect != null)
            fieryEffect.SetActive(true);
        if (smokeEffect != null)
            smokeEffect.SetActive(true);
        if (explodeEffect != null)
            explodeEffect.SetActive(false);
    }
}
