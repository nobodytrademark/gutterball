using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject pointstext;
    [SerializeField] int winCondition = 100;
    public static int points = 0;
    public static int health = 15;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public static void alterHealth(int i)
    {
        health += i;
        if (health < 1) { health = 0; gameover(); }
    }

    private static void gameover()
    {
        Time.timeScale = 0;
    }

    private static void victory()
    {
        Time.timeScale = 0;
    }
}
