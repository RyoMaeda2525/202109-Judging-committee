using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEmperorZalaras : MonoBehaviour
{
    private BossState nowState = BossState.StartEnsyutu;
    Animator ani = default;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)  //←nowStateには現在の状態が入っている
        {
            case BossState.StartEnsyutu:
                ani.Play("Start");
                nowState = BossState.Battle;
                break;
            case BossState.Battle:
                //戦闘中の処理を書く
                break;
            case BossState.ClearEnsyutu:
                //クリア時の処理を書く
                break;
        }
    }

    private enum BossState  //←「BossState」の部分はenumの名前（自分で定義する）
    {
        StartEnsyutu,  //←好きなように名前をつけることができる
        Battle,
        ClearEnsyutu,
    }
}
