using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    Image ima = default;
    float alfa = 0;
    public  float speed = 0.005f;
    float red, green, blue;
    bool m_color = false;

    void Start()
    {
        ima = GetComponent<Image>();
        red = ima.color.r;
        green = ima.color.g;
        blue = ima.color.b;
        alfa = ima.color.a;
        alfa = 0;
    }

    void Update()
    {
        if (m_color)
        {
            ima.color = new Color(red, green, blue, alfa);
            alfa += speed;
            if (alfa >= 1)
            {
                Debug.Log("a");
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void ColorChange()
    {
        m_color = true;
    }
}
