using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class StartLevel : MonoBehaviour
{
    [SerializeField] string path;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(transition);
        if (!File.Exists(path + ".state"))
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void transition()
    {
        SceneManager.LoadScene(path);
    }
}
