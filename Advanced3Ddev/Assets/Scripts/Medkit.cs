using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
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
        if(GameManager.GetInstance().Health < 100)
        {
            GameManager.GetInstance().AddHealth();
            Destroy(gameObject);
        }
    }
}
