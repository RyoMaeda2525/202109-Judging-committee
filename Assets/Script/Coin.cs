using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip audio;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!touch)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerManager>().AddScore();
                touch = true;
                StartCoroutine(Audio());
                //AudioSource.PlayClipAtPoint(audio, transform.position);
            }
        }
    }
    public IEnumerator Audio()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
