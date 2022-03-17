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
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI ghostsUI;
    [SerializeField] TextMeshProUGUI healthUI;
    public bool one = false;
    public bool two = false;
    public bool three = false;

    void Start()
    {
        instance = this;
        score = 0;
        ghosts = 0;
        healthUI.text = 100.ToString();
    }
    // Update is called once per frame
    void UpdateUI()
    {
        scoreUI.text = "Score: " + score;
        ghostsUI.text = "Ghosts killed: " + ghosts;
        healthUI.text = health.ToString();
    }
    public void AddPoint()
    {
        score++;
        UpdateUI();
    }
    public void AddGhost()
    {
        ghosts++;
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
}
