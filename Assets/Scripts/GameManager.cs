﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    private LevelManager levelManager;
    public Text scoreText;
    public Text livesText;
    private int score;
    private int lives;

    void Awake() {
        if (Instance)
        {
            foreach (Transform child in transform) {
                DestroyImmediate(child.gameObject);
            }
            DestroyImmediate(this);
        }
        else{
            Instance = this;
            score = 0;
            lives = 5;
            SetScoreText();
            DontDestroyOnLoad(gameObject);
        }
        setLevelManager(GameObject.Find("LevelManager").GetComponent<LevelManager>());
    }

	// Use this for initialization
	void Start () {
        
        SetScoreText();
        SetLivesText();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setLevelManager(LevelManager m)
    {
        levelManager = m;
    }

    public void GoToNextLevel() {
        levelManager.GetComponent<LevelManager>().GoToNextLevel();
    }

    public void AddScore(int ammount)
    {
        score += ammount;
        SetScoreText();
    }

    public void AddLife()
    {
        lives++;
        SetLivesText();
    }

    public void DestroyLife()
    {
        lives--;
        if (lives == 0) {
            Application.LoadLevel("gameOver");
        }
        SetLivesText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void SetLivesText()
    {
        livesText.text = "lives: " + lives;
    }
}
