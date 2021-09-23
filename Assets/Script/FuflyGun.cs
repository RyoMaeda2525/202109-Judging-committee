using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuflyGun : MonoBehaviour
{
    Vector3 playerpos = default;
    [SerializeField] GameObject m_bulletPrefab = default;
    public float Fireinterval = 1;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > Fireinterval)
        {
            Fire();
            timer = 0;
        }
    }

    void Fire()
    {
        playerpos = GameObject.FindWithTag("Player").transform.position;
        Instantiate(m_bulletPrefab, this.transform.position, Quaternion.identity);
    }
}
