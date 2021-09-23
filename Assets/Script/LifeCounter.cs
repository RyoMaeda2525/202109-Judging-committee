using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    /// <summary>残機として表示するスプライト</summary>
    [SerializeField] Sprite m_playerUiSprite = null;
    [SerializeField] Sprite m_playerUiSprite2 = null;
    /// <summary>残機として表示するスプライトのサイズ</summary>
    [SerializeField] Vector2 m_spriteSize = new Vector2(50f, 50f);
    /// <summary>残機表示をするパネル</summary>
    [SerializeField] RectTransform m_playerLifePanel = null;

    /// <summary>
    /// 残機表示を更新する
    /// </summary>
    /// <param name="lifeCount">残機数</param>
    public void Refresh(int lifeCount)
    {
        if (m_playerUiSprite && m_playerLifePanel)
        {
            // 子オブジェクトをすべて削除する
            foreach (Transform t in m_playerLifePanel.transform)
            {
                Destroy(t.gameObject);
            }

            // 残機数だけスプライトをパネルの子オブジェクトとして生成する
            for (int i = 0; i < 3 - lifeCount; i++)
            {
                // Image を作る
                GameObject go = new GameObject();
                Image image = go.AddComponent<Image>();
                // Sprite をアサインする
                image.sprite = m_playerUiSprite2;
                // サイズを変える
                RectTransform rect = go.GetComponent<RectTransform>();
                rect.sizeDelta = m_spriteSize;
                // パネルの子オブジェクトにする
                go.transform.SetParent(m_playerLifePanel.transform);
            }
            for (int i = 0; i < lifeCount; i++)
            {
                // Image を作る
                GameObject go = new GameObject();
                Image image = go.AddComponent<Image>();
                // Sprite をアサインする
                image.sprite = m_playerUiSprite;
                // サイズを変える
                RectTransform rect = go.GetComponent<RectTransform>();
                rect.sizeDelta = m_spriteSize;
                // パネルの子オブジェクトにする
                go.transform.SetParent(m_playerLifePanel.transform);
            }
        }
    }
}
