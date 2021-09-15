using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] floors;
    // Start is called before the first frame update
    void Start()
    {
        GameObject floor = Instantiate(floors[0]);
        floor.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
