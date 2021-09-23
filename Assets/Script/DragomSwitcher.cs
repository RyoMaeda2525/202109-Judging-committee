using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragomSwitcher : MonoBehaviour
{
    [SerializeField] GameObject m_Dragon;
    [SerializeField] GameObject m_Cinema;
    [SerializeField] GameObject m_Cinema2;
    [SerializeField] PlayerCamera m_Player = default;
    

    void Start()
    {
        m_Cinema = GameObject.FindGameObjectWithTag("Cinema1");
    }

    public void TurnOff()
    {
        if (m_Dragon)
        {
            m_Dragon.SetActive(false);
        }
    }

    public void TurnOn()
    {
        if (m_Dragon)
        {
            m_Dragon.SetActive(true);
        }
    }

    public void TurnONCinima()
    {
        if (m_Cinema)
        {
            m_Dragon.SetActive(true);
        }
    }

    public void TurnOFFCinima()
    {
        if (m_Cinema)
        {
            m_Dragon.SetActive(false);
        }
    }

    public void TurnOnCinimaSecond()
    {
        
    }

    public void TurnOffCinimaSecond()
    {
        if (m_Cinema2)
        {
            m_Dragon.SetActive(false);
        }
    }
}
