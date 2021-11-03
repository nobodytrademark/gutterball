using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject textdisplay;
    public static bool activate = false;
    bool sentry = true;
    public static string text = "";

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (EndScreen.activate && sentry)
        {
            Debug.Log("END");
            sentry = false;
            GetComponent<Canvas>().enabled = true;
            textdisplay.gameObject.GetComponent<Text>().text = text;
        }
    }

}
