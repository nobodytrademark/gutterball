using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] int value = 0;
    [SerializeField] double timestamp; /* Fallback for calculating which to kill */

    // Start is called before the first frame update
    void Start()
    {
        //push(5.0f, 5.0f);
        timestamp = UnityEngine.Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void push(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ball>() is Ball && col.gameObject.GetComponent<Ball>().value == this.value)
        {
            float a = (float)Math.Sqrt(Math.Pow((double)col.gameObject.GetComponent<Rigidbody2D>().velocity.x, 2) + Math.Pow((double)col.gameObject.GetComponent<Rigidbody2D>().velocity.y, 2));
            float b = (float)Math.Sqrt(Math.Pow((double)GetComponent<Rigidbody2D>().velocity.x, 2) + Math.Pow((double)GetComponent<Rigidbody2D>().velocity.y, 2));
            Debug.Log(a);
            Debug.Log(b);
            if (a == b && col.gameObject.GetComponent<Ball>().timestamp > timestamp) /* Ensure velocities are not the same */
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
            }
        }
    }
}
