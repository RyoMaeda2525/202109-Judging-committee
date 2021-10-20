using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownFireResporn : MonoBehaviour
{
    Vector3 playerpos = default;
    [SerializeField] GameObject m_bulletPrefab = default;
    public float FireDownInterval = 1;
    public float timer = 0;
    bool stop = false;

    void Update()
    {
        if (!stop)
        {
            timer += Time.deltaTime;
            if (timer > FireDownInterval)
            {
                GetComponent<Animator>().Play("FireDown");
                stop = true;
            }
        }    
    }

    void Fire()
    {
        playerpos = GameObject.FindWithTag("Player").transform.position;
        Instantiate(m_bulletPrefab, this.transform.position, Quaternion.identity);
    }
}
