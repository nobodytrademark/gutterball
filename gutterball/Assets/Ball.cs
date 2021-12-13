using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] public int value = 1;
    [SerializeField] float vol = .5f;
    [SerializeField] public AudioClip woosh;
    int id;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = ColorPool.getColor(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setId(int i) { id = i; }

    public void push(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource aud = GetComponent<AudioSource>();
        if (col.gameObject.GetComponent<Ball>() is Ball)
        {
            if (col.gameObject.GetComponent<Ball>().value == this.value) 
            {
                float a = (float)Math.Sqrt(Math.Pow((double)col.gameObject.GetComponent<Rigidbody2D>().velocity.x, 2) + Math.Pow((double)col.gameObject.GetComponent<Rigidbody2D>().velocity.y, 2));
                float b = (float)Math.Sqrt(Math.Pow((double)GetComponent<Rigidbody2D>().velocity.x, 2) + Math.Pow((double)GetComponent<Rigidbody2D>().velocity.y, 2));
                Debug.Log("I am getting a colission!");
                if (a == b && col.gameObject.GetComponent<Ball>().id > id) /* Ensure velocities are not the same */
                {
                    Destroy(this.gameObject);
                }
                else if (a > b) /* If there are different velocities then  */
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    value++;
                    GetComponent<SpriteRenderer>().color = ColorPool.getColor(value);
                    GameState.points += value;
                    GameState.alterHealth(1);
                    Destroy(col.gameObject);
                }
                aud.PlayOneShot(woosh, vol);
            }
            else
            {
                aud.PlayOneShot(aud.clip, .2f);
            }
        }
    }
}
