using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //push(5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void push(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }
}
