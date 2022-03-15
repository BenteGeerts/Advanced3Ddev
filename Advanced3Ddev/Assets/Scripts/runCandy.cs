using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runCandy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.GetInstance().one = true;
        GameManager.GetInstance().two = true;
        GameManager.GetInstance().three = true;

    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.GetInstance().one = false;
        GameManager.GetInstance().two = false;
        GameManager.GetInstance().three = false;
    }
}
