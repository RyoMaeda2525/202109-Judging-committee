using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    public bool isFloor = false;
    public PlayerManager m_FloorCheck;
    public bool IsFloorCheck = false;
    public GameObject[] floors;
    public int i = 0;
    public int start = 0;
    public int end = 2;
    public int ransu = 0;
    List<int> numbers = new List<int>();
    public GameObject bossPrefab = default;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = start; i < end; i++)
        {
            numbers.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsFloorCheck = m_FloorCheck.Floor();
        if (IsFloorCheck == true)
        {
            if (numbers.Count > 0)
            {
                Vector3 pos = this.transform.position;
                pos.y += 3;
                pos.z = 0;
                int index = Random.Range(0, numbers.Count);
                ransu = numbers[index];
                GameObject floor = Instantiate(floors[ransu]);
                floor.transform.position = pos;
                this.transform.position = pos;
                m_FloorCheck.GroundCheck = false;
                numbers.RemoveAt(index);
                IsFloorCheck = false;
            }
            else
            {
                Vector3 pos = this.transform.position;
                pos.y += 3;
                pos.z = 0;
                GameObject floor = Instantiate(bossPrefab);
                floor.transform.position = pos;
                this.transform.position = pos;
                this.gameObject.SetActive(false);
                m_FloorCheck.GroundCheck = false;
                IsFloorCheck = false;
            }
        }

    }
}
