using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager GetInstance() { return instance; }
    int score = 0;
    int ghosts = 0;
    int health = 100;
    int ghostsLeft = 3;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI ghostsLeftUI;
    [SerializeField] TextMeshProUGUI highScoreUI;
    public HealthBar healtBar;
    public bool candyTaken = false;
    public bool slow;
    public bool fast;
    public bool spawn = false;
    void Start()
    {
        instance = this;
        healtBar = healtBar.GetComponent<HealthBar>();
        score = 0;
        ghosts = 0;
        ghostsLeft = 3;
        healtBar.SetMaxHealth(health);
        UpdateUI();
    }
    public void UpdateUI()
    {
        scoreUI.text = "Score: " + score;
        healtBar.SetHealth(health);
        ghostsLeftUI.text = "Ghosts left: " + ghostsLeft;
        highScoreUI.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    public void AddPoint()
    {
        score++;
        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        UpdateUI();
    }
    public void AddGhost()
    {
        ghosts++;
        ghostsLeft--;
        score = score + 100;
        UpdateUI();
    }
    public void LoseHealth()
    {
        if(health >= 10)
        {
            health = health - 10;
            UpdateUI();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
       
    }

    public void AddHealth()
    {
        health = health + 50;
        if(health > 100)
        {
            health = 100;
        }
        UpdateUI();
    }

    public int Score
    {
        get { return score; }
    }
    public int Ghosts
    {
        get { return ghosts; }
    }
    public int Health
    {
        get { return health; }
    }
    public int GhostsLeft
    {
        get { return ghostsLeft; }
        set { ghostsLeft = value; }
    }
}
