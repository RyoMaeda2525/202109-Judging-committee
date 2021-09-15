using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    public bool isFloor = false;
    public PlayerManager m_FloorCheck;
    public bool IsFloorCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsFloorCheck = m_FloorCheck.Floor();
        if (IsFloorCheck == true)
        {
            Debug.Log("a");
            Vector3 pos = this.transform.position;
            pos.y += 3;
            pos.z = -10;
            this.transform.position = pos;
            m_FloorCheck.GroundCheck = false;
        }
    }
}
