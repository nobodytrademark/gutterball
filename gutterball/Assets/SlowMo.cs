using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    float scale = 1.5f;
    [SerializeField] float upperbound = 1.5f;
    [SerializeField] float lowerbound = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scale += Input.mouseScrollDelta.y;
        if (scale > upperbound)
        {
            scale = upperbound;
        } else if (scale < lowerbound)
        {
            scale = lowerbound;
        }

        if (!EndScreen.activate)
        {
            Time.timeScale = scale;
                }
        else
        { Time.timeScale = 0; }
    }
}
