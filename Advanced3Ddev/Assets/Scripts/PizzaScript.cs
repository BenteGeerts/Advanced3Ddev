using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PizzaScript : MonoBehaviour
{
    public bool entered = false;
    float time = 10f;
    void Update()
    {
        if(entered)
        {
            Slow();
        }
    }

    void Slow()
    {
        Time.timeScale = 0.5f;
        time = time - Time.deltaTime;
        Debug.Log(time);
        GameManager.GetInstance().slow = true;
        if (time < 0f)
        {
            GameManager.GetInstance().LoseHealth();
            GameManager.GetInstance().slow = false; 
            Time.timeScale = 1f;
            entered = false;
            time = 10f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        entered = true;
    }
}
