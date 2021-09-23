using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerManager m_playerManager= null;
    //[SerializeField] SceneLoader m_sceneLoader = null;
    [SerializeField] public int m_life = 2;
    public static int m_score = 0;
    [SerializeField] Text m_scoreText = null;
    LifeCounter m_LifeCounter;
    public int bossScore = 5000;
    public static float GameTimer = 0;
    bool gameClear = false;
    bool IsFloorCheck = false;
    AudioSource audio = default;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        m_LifeCounter = GetComponent<LifeCounter>();
        m_LifeCounter.Refresh(m_life);
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        IsFloorCheck = m_playerManager.BossFloor();
        if (!gameClear)
        {
            GameTimer += Time.deltaTime;
        }
        if (IsFloorCheck)
            audio.Stop();
    }

    public void AddScore(int score)
    {
        m_score += score;
        if (m_scoreText)
        {
            m_scoreText.text = "Score: " + m_score .ToString("d10"); // 10桁でゼロ埋め (zero padding) する
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

    public void GameClear()
    {
        gameClear = true;
        m_score += bossScore;
        if(GameTimer < 180)
        {
            m_score += 3000;
        }else if(GameTimer < 300)
        {
            m_score += 2000;
        }else if(GameTimer < 600)
        {
            m_score += 1000;
        }
        getScore();
        SceneManager.LoadScene("GameResult");
    }
    public static int getScore()
    {
        return m_score;
    }
    public static float getTime()
    {
        return GameTimer;
    }

}
