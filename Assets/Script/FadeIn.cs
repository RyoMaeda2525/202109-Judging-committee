using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float alfa = 255;
    float speed = 0.005f;
    float red, green, blue;
    bool m_color = true;
    // Start is called before the first frame update
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
            alfa -= speed;
            if(alfa <= 0)
            {
                m_color = false;
            }
        }
        else
        {
            
        } 
    }


}
