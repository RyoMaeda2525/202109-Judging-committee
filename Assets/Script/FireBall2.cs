using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class FireBall2 : MonoBehaviour
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
    List<ParticleSystem> pa = new List<ParticleSystem>();

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
        playerpos = GameObject.FindWithTag("Player").transform.position;
        rgbd = GetComponent<Rigidbody2D>();
        vero.x = playerpos.x - this.transform.position.x;
        vero.y = playerpos.y - this.transform.position.y;
        vero = vero.normalized * m_moveSpeed;
        rgbd.velocity = vero;
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

    public void StopParticleSystem(GameObject g)
    {
        ParticleSystem[] par;
        par = g.GetComponentsInChildren<ParticleSystem>();
        pa.AddRange(par);
        //foreach (ParticleSystem p in par)
        //{
        //    p.Stop();
        //}
        pa.Where(i => pa != null).ToList().ForEach(i => i.Stop());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
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