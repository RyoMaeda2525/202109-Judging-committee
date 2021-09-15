using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zonbie : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == ("Bullet"))
        {
            StartCoroutine(ColorChange());
            Debug.Log("a");
        }
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
