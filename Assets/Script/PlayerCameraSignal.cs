using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSignal : MonoBehaviour
{
    [SerializeField] GameObject m_Cinema2;
    [SerializeField] PlayerCamera m_Player = default;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponent<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerFollow()
    {
        //m_Player.PlayerFollow();
    }
}
