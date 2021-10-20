using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    //int score = GameManager.getScore();
    //float time = GameManager.getTime();
    //[SerializeField] Text m_scoreText = default;
    //[SerializeField] Text m_timerText = default;
    Text sp = default;

    // Start is called before the first frame update
    void Start()
    {
        //int seconds = (int)time;
        sp = GetComponent<Text>();
        //m_scoreText.text = "Score: " + score.ToString("d10"); // 10桁でゼロ埋め (zero padding) する
        //m_timerText.text = "Time : " + ((int)seconds) + "s";
    }

    // Update is called once per frame
    void Update()
    {
        float level = Mathf.Abs(Mathf.Sin(Time.time * 1));
        sp.color = new Color(1f, 1f, 1f, level);

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
