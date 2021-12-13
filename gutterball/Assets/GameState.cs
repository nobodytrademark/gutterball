using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject pointstext;
    [SerializeField] int winCondition = 100;
    static float dificultystep = 0.04f;
    static float difcurrent = 0f;
    public static int points = 0;
    public static int health = 15;

    static string[] levels = {"start", "slowdown", "redball", "bouncer2"}; 

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        health = 15;
        difcurrent = 0;
        EndScreen.activate = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pointstext.GetComponent<Text>().text = points.ToString();
        string healthstring = "";
        for(int i = 0; i < health; i++) { healthstring += "█"; }
        healthbar.GetComponent<Text>().text = healthstring;

        if (points > winCondition)
        {
            victory();
        }
    }

    public static void alterHealth(float i)
    {
        if (i < 0) { i -= difcurrent; difcurrent += dificultystep; }
        health += (int) i;
        if (health < 1) { health = 0; gameover(); }
        Debug.Log(health);
    }

    private static void gameover()
    {
        Time.timeScale = 0;
        EndScreen.activate = true;
        EndScreen.text = "Game Over.";
    }

    private static void victory()
    {
        Time.timeScale = 0;
        EndScreen.activate = true;
        EndScreen.text = "Victory.";

        Scene scene = SceneManager.GetActiveScene();
        string fpath = scene.name + ".state";
        if (!File.Exists(fpath))
        {
            using (StreamWriter fhandle = File.CreateText(fpath))
            {
                fhandle.Write("a");
            }
        }
        int i = 0;
        for (i = 0; i < levels.Length; i++)
        {
            if (levels[i] == scene.name)
            {
                break;
            }
        }

        if (i + 1 < levels.Length)
        {
            fpath = levels[i + 1] + ".state";
            if (!File.Exists(fpath))
            {
                using (StreamWriter fhandle = File.CreateText(fpath))
                {
                    fhandle.Write("a");
                }
            }
        }
    }
}
