using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerManager m_playerManager = null;
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
    [SerializeField] FadeOut m_Panal = default;
    float colortimer = 0;
    bool LifeCount = true;
    bool bossClear = false;
    bool healInterval = false;
    int m_maxScore = 99999999;
    float m_scoreChangeInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        m_life = 2;
        m_LifeCounter = GetComponent<LifeCounter>();
        m_LifeCounter.Refresh(m_life);
        m_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameClear)
        {
            GameTimer += Time.deltaTime;
        }
        if (IsFloorCheck)
            audio.Stop();
        if (m_score > 1)
        {
            if (m_score % 1000 == 0 && m_life <= 2 && LifeCount && healInterval == false)
            {
                m_life += 1;
                LifeCount = false;
                m_LifeCounter.Refresh(m_life);
                healInterval = true;
            }
            else if (m_score % 1000 != 0)
            {
                healInterval = false;
            }
        }
    }


    public void AddScore(int score)
    {
        if (m_scoreText)
        {
            int tempScore = m_score;
            m_score = Mathf.Min(m_score + score, m_maxScore);

            // カンストしてなかったら得点表示を更新する
            if (tempScore != m_maxScore)
            {
                DOTween.To(() => tempScore,
                    x => tempScore = x,
                    m_score,
                    m_scoreChangeInterval)
                    .OnUpdate(() => m_scoreText.text = tempScore.ToString("00000000"))
                    .OnComplete(() => m_scoreText.text = m_score.ToString("00000000"));
                LifeCount = true;
            }
        }
    }

    public void PlayerDead()
    {
        if (!bossClear)
        {
            if (m_life != 1)
            {
                m_life -= 1;
                m_LifeCounter.Refresh(m_life);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                m_life -= 1;
                m_LifeCounter.Refresh(m_life);
                m_playerManager.Dead();
            }
        }
    }

    public void BossClear()
    {
        bossClear = true;
    }

    public void GameClear()
    {
        gameClear = true;
        m_score += bossScore;
        if (GameTimer < 180)
        {
            m_score += 3000;
        }
        else if (GameTimer < 300)
        {
            m_score += 2000;
        }
        else if (GameTimer < 600)
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
