using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    bool m_color = false;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
    }

    void Update()
    {
        if (m_color)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
    }

    public void ColorChange()
    {
        m_color = true;
    }
}
