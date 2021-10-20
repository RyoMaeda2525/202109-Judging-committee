using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroy : MonoBehaviour
{
    PlayerManager m_pla = default;
    // Start is called before the first frame update
    void Start()
    {
        m_pla = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        m_pla.LightDeth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
