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
    [SerializeField] TextMeshProUGUI scoreUI;
    public bool running = false;


    void Start()
    {
        instance = this;
        score = 0;
    }
    // Update is called once per frame
    void UpdateUI()
    {
        scoreUI.text = "Score: " + score;
    }
    public void AddPoint()
    {
        score++;
        UpdateUI();
    }
    public int Score
    {
        get { return score; }
    }
}
