using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaSpawner : MonoBehaviour
{
    public GameObject pizza;
    int xPos;
    int enemyCount;
    int zPos;


    void Start()
    {
        StartCoroutine(PizzaDrop());
    }


    IEnumerator PizzaDrop()
    {
        while (enemyCount < 40)
        {
            xPos = Random.Range(216, 481);
            zPos = Random.Range(-56, 18);
            Instantiate(pizza, new Vector3(xPos, -1.658f, zPos), Quaternion.identity);
            yield return null;
            enemyCount++;
        }
    }
}
