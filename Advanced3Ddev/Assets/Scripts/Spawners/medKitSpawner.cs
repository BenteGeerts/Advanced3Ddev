using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medKitSpawner : MonoBehaviour
{
    public GameObject medkit;
    int xPos;
    int enemyCount;
    int zPos;


    void Start()
    {
        StartCoroutine(CoinDrop());
    }


    IEnumerator CoinDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(216, 481);
            zPos = Random.Range(-56, 18);
            Instantiate(medkit, new Vector3(xPos, -2.44f, zPos), Quaternion.identity);
            yield return null;
            enemyCount++;
        }
    }
}
