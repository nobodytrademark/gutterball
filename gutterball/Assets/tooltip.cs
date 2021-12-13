using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tooltip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y);
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(this.gameObject);
        }
    }
}
