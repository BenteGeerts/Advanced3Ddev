using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.GetInstance().Health < 100)
        {
            GameManager.GetInstance().AddHealth();
            Destroy(gameObject);
        }
    }
}
