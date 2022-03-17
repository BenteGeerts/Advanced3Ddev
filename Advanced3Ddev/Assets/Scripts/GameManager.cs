using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager GetInstance() { return instance; }
    int score = 0;
    int ghosts = 0;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI ghostsUI;
    public bool one = false;
    public bool two = false;
    public bool three = false;

    void Start()
    {
        instance = this;
        score = 0;
        ghosts = 0;
    }
    // Update is called once per frame
    void UpdateScore()
    {
        scoreUI.text = "Score: " + score;
    }
    void UpdateGhosts()
    {
        ghostsUI.text = "Ghosts killed: " + ghosts;
    }
    public void AddPoint()
    {
        score++;
        UpdateScore();
    }
    public void AddGhost()
    {
        ghosts++;
        UpdateGhosts();
    }

    public int Score
    {
        get { return score; }
    }
    public int Ghosts
    {
        get { return ghosts; }
    }
}
