using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSpawn : MonoBehaviour
{
    public GameObject blue;
    public GameObject pink;
    public GameObject yellow;
    void Start()
    {

    }

    void Update()
    {
        if(GameManager.GetInstance().GhostsLeft == 2)
        {
            Instantiate(blue, transform.position, Quaternion.identity);
            Instantiate(pink, transform.position, Quaternion.identity);
            Instantiate(yellow, transform.position, Quaternion.identity);
            GameManager.GetInstance().GhostsLeft += 3;
        }
    }
}
