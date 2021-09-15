using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeadUpManager : ItemBase
{
    // Start is called before the first frame update
    [SerializeField] float m_speed = 0.5f;

    public override void Activate()
    {
        FindObjectOfType<PlayerManager>().AddSpead(m_speed);
    }
}
