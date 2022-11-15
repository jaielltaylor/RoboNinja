using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public int patrollersDestroyed;
    public int score;
    private int onStartPatrollers;
    private int currentScene;

    public bool missionComplete;
    private bool alreadyCalculated;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        onStartPatrollers = 8;
        score = 0;
        alreadyCalculated = false;
        missionComplete = false;
    }
    void Update()
    {
        //Check for current scene
        currentScene = SceneManager.GetActiveScene().buildIndex;
        //If the scene is either the win or death scene (indexes 2 or 3)
        if (currentScene >= 2 && alreadyCalculated == false)
        {
            CalculateScore();
            alreadyCalculated = true;
        }
    }
    void CalculateScore()
    {
        //Calculate Patrol Bots Destroyed Points
        score += (patrollersDestroyed * 10);
        //Calculate Patrol Bots Remaining Points
        if (missionComplete == true)
        {
            score += ((onStartPatrollers - patrollersDestroyed) * 20);
        }
        //Displaying Score
        GameObject totalScore = GameObject.Find("ScoreText");
        totalScore.GetComponent<Text>().text = "Patrol Bots Destroyed: " + patrollersDestroyed
        + Environment.NewLine + "Patrol Bots Remaining: " + (onStartPatrollers - patrollersDestroyed)
        + Environment.NewLine + "Total Score: " + score;
    }
}
