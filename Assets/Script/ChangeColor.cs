using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame updat
    public Color startColor;
    public Color endColor;
    public Color LastColor;

    [Range(0f, 1f)]
    public float t;
    [Range(0f, 1f)]
    public float u;

    SpriteRenderer MeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ColorChange()
    {
        MeshRenderer.color = Color.Lerp(startColor, endColor, t);
        t += Time.deltaTime;
        if (t >= 1)
        {
            MeshRenderer.color = Color.Lerp(endColor, LastColor, u);
            u += Time.deltaTime;
        }
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }
}
