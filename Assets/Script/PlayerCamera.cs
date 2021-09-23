using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cinema = default;
    [SerializeField] GameObject Bosscinema= default;
    public GameObject m_Player = default;
    [SerializeField] GameObject m_Boss = default;
    public float cameraTimer = 6f;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        cinema = GetComponent<CinemachineVirtualCamera>();
        //if (!m_Player)
        //{
        //    cinema.Follow = m_Player.transform;
        //}
        //m_Boss = GameObject.FindWithTag("BossMotion");
        cinema.Follow = m_Boss.transform;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > cameraTimer)
        {
            this.gameObject.SetActive(false);
            Bosscinema.SetActive(true);
        }
        //m_Player = GameObject.FindWithTag("Player");
    }

    //public void PlayerFollow()
    //{
    //    cinema.Follow = m_Player.transform;
    //}
}
