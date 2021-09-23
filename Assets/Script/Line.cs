using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] GameObject Cube_1 = default;
    [SerializeField] GameObject Cube_2 = default;

    // Start is called before the first frame update
    void Start()
    {
        //    GameObject Cube_1 = GameObject.Find("Cube_1");
        //    //Cube_1はlineの始点にあるオブジェクト

        //    GameObject Cube_2 = GameObject.Find("Cube_2");
        //    //Cube_2はlineの終点にあるオブジェクト

        LineRenderer line = GameObject.Find("Line").GetComponent<LineRenderer>();

        line.SetPosition(0, Cube_1.transform.position);
        line.SetPosition(1, Cube_2.transform.position);
        //line.SetPosition関数の第一引数は配列の要素数(配列は0スタートです！,第二引数は座標です)

        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        //lineの太さを決められます。
    }

    // Update is called once per frame
    void Update()
    {

    }
}
