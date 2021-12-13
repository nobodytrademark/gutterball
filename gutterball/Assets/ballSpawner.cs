using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _launchForce = 5;
    GameObject hold;
    float sentry = 0;
    int number = 0;
    [SerializeField] float launchDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && sentry <= 0)
        {
            hold = Instantiate(_ball, this.gameObject.transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float xdist = mousePosition.x - this.gameObject.transform.position.x;
            float ydist = mousePosition.y - this.gameObject.transform.position.y;
            float ntan = Mathf.Atan2(ydist, xdist);
            //Debug.Log(xdist);
            //Debug.Log(ydist);
            //Debug.Log(ntan);
            //Debug.Log(Mathf.Cos(ntan));
            //Debug.Log(Mathf.Sin(ntan));
            hold.GetComponent<Ball>().push(Mathf.Cos(ntan) * _launchForce, Mathf.Sin(ntan) * _launchForce);
            hold.GetComponent<Ball>().setId(number);
            hold.GetComponent<Ball>().value = 1;
            number++;
            sentry = launchDelay;
            GameState.alterHealth(-1);
        }

        if (sentry > 0) { sentry -= Time.deltaTime; }
    }
}
