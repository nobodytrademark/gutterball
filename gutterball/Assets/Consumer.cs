using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Consumer : MonoBehaviour
{
    [SerializeField] int value = 0;
    [SerializeField] float vol = .5f;
    [SerializeField] public AudioClip woosh;
    [SerializeField] int level = 3;


    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource aud = GetComponent<AudioSource>();
        if (col.gameObject.GetComponent<Ball>() is Ball)
        {
            GameState.points -= col.gameObject.GetComponent<Ball>().value;
            Destroy(col.gameObject);
            level--;
            aud.PlayOneShot(woosh, vol);
            if (level > 0)
            {
                GetComponent<SpriteRenderer>().color = ColorPool.getRed(level);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void push(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }
}
