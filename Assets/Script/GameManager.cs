using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerManager m_playerManager= null;
    //[SerializeField] SceneLoader m_sceneLoader = null;
    [SerializeField] public int m_life = 2;
    int m_score = 0;
    [SerializeField] Text m_scoreText = null;
    LifeCounter m_LifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        m_LifeCounter = GetComponent<LifeCounter>();
        m_LifeCounter.Refresh(m_life);
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        m_score += score;
        if (m_scoreText)
        {
            m_scoreText.text = "Score: " + m_score; // 10桁でゼロ埋め (zero padding) する
        }
    }

    public void PlayerDead()
    {
        if(m_life != 1)
        {
            m_life -= 1;
            m_LifeCounter.Refresh(m_life);
        }
        else
        {
            m_life -= 1;
            m_LifeCounter.Refresh(m_life);
            m_playerManager.Dead();
        }
    }

}
