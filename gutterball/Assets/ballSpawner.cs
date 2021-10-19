using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    GameObject hold;
    bool sentry = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sentry)
        {
            hold = Instantiate(_ball, this.gameObject.transform.position, Quaternion.identity);
            sentry = false;
        }

        if (Input.GetButtonDown("Fire1") && !sentry)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float xdist = mousePosition.x - this.gameObject.transform.position.x;
            float ydist = mousePosition.y - this.gameObject.transform.position.y;
            float ntan = Mathf.Atan(ydist / xdist);
            Debug.Log(xdist);
            Debug.Log(ydist);
            Debug.Log(ntan);
            Debug.Log(Mathf.Cos(ntan));
            Debug.Log(Mathf.Sin(ntan));
            hold.GetComponent<Ball>().push(Mathf.Cos(ntan) + 4.0f, Mathf.Sin(ntan) + 4.0f);
            sentry = true;
        }
    }
}
