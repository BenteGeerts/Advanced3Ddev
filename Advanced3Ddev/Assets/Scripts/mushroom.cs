using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    public bool entered = false;
    float time = 10f;
    void Update()
    {
        if (entered)
        {
            Fast();
        }
    }

    void Fast()
    {
        Time.timeScale = 2f;
        time = time - Time.deltaTime;
        Debug.Log(time);
        GameManager.GetInstance().fast = true;
        if (time < 0f)
        {
            GameManager.GetInstance().fast = false;
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
