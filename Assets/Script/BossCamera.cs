using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    [SerializeField] PlayerManager m_FloorCheck = default;
    CinemachineVirtualCamera cinema = default;
    GameObject m_Boss = default;
    bool IsFloorCheck = false;
    [SerializeField] GameObject m_Player = default;
    private float Changetimer = 0;
    public float Bosstimer = 6;

    // Start is called before the first frame update
    void Start()
    {
        cinema = GetComponent<CinemachineVirtualCamera>();
        m_Player = GameObject.FindWithTag("Player");
        cinema.Follow = m_Player.transform;
        //cinema.Follow = m_Boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //IsFloorCheck = m_FloorCheck.BossFloor();
        //IsFloorCheck = m_FloorCheck.Floor();
        //if (IsFloorCheck)
        //{
        //    Debug.Log("G");
        //    this.gameObject.SetActive(false);
        //    //    Changetimer += Time.deltaTime;
        //    //    cinema.Follow = m_Player.transform;
        //    //    if(Changetimer > Bosstimer)
        //    //    {
        //    //        this.gameObject.SetActive(true);
        //    //    }
        //    //}
        //    //m_Boss = GameObject.FindWithTag("BossMotion");
        //    //if (m_Boss == true)
        //    //{
        //    //    cinema.Follow = m_Boss.transform;
            //}
        //}
    }

    //public void Follow()
    //{
    //    cinema.Follow = m_Player.transform;
    //}

}

